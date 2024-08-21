[TestFixture]
public class EditTeamMemberTests : BaseTest
{
    [Test]
    public async Task EditUserData()
    {
        var teamMemberData = ConfigReader.GetTeamMemberData();
        var addTeamMemberPage = new AddTeamMemberPage(Page);

        await Login();
        await BaseFunctions.ClickAsync(Locators.HomePage.SetupLink);
        await BaseFunctions.AssertTextContainsAsync(Locators.SetupPage.PageTitle, "Setup");
        await BaseFunctions.ClickAsync(Locators.SetupPage.ManageTeamMembersLink);
        await Page.WaitForTimeoutAsync(3000);
        await Page.ReloadAsync();
        await BaseFunctions.ClickAsync(Locators.AddTeamMember.SearchTeamMembers_Xpath);

        await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.SearchTeamMembers_Xpath, teamMemberData.LastName);
        await Page.PressAsync(Locators.AddTeamMember.SearchTeamMembers_Xpath, "Enter");
        await Page.WaitForTimeoutAsync(5000);

        var userRowXPath = $"//tbody/tr[1]/td[5]/a[@role='link']";
        await BaseFunctions.ClickAsync(userRowXPath);
        await Page.WaitForTimeoutAsync(3000);

        await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.FirstName_Xpath, $"{teamMemberData.FirstName}1");
        await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.LastName_Xpath, $"{teamMemberData.LastName}1");

        await BaseFunctions.ClickAsync(Locators.AddTeamMember.SaveAndCloseButton_Xpath);

        await addTeamMemberPage.HandleAlertOrSuccessAsync(Locators.AddTeamMember.Alert_Xpath, Locators.AddTeamMember.SearchTeamMembers_Xpath, "output.csv");

        await Page.WaitForTimeoutAsync(3000);
        await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.SearchTeamMembers_Xpath, $"{teamMemberData.LastName}1");
        await Page.WaitForTimeoutAsync(5000);

        await BaseFunctions.ClickAsync(userRowXPath);

        string updatedFirstName = await Page.InputValueAsync(Locators.AddTeamMember.FirstName_Xpath);
        string updatedLastName = await Page.InputValueAsync(Locators.AddTeamMember.LastName_Xpath);

        Assert.That(updatedFirstName, Is.EqualTo($"{teamMemberData.FirstName}1"));
        Assert.That(updatedLastName, Is.EqualTo($"{teamMemberData.LastName}1"));
    }
}
