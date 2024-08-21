[TestFixture]
public class DeleteTeamMemberTests : BaseTest
{
    [Test]
    public async Task DeleteUserData()
    {
        var teamMemberData = ConfigReader.GetTeamMemberData();

        await Login();
        await BaseFunctions.ClickAsync(Locators.HomePage.SetupLink);
        await BaseFunctions.AssertTextContainsAsync(Locators.SetupPage.PageTitle, "Setup");
        await BaseFunctions.ClickAsync(Locators.SetupPage.ManageTeamMembersLink);
        await Page.WaitForTimeoutAsync(5000);

        await Page.ReloadAsync();
        await BaseFunctions.ClickAsync(Locators.AddTeamMember.SearchTeamMembers_Xpath);

        await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.SearchTeamMembers_Xpath, teamMemberData.LastName);
        await Page.WaitForTimeoutAsync(5000);

        var userRowXPath = $"//tbody/tr[1]/td[5]/a[@role='link']";
        await BaseFunctions.ClickAsync(userRowXPath);
        await Page.WaitForTimeoutAsync(5000);

        await BaseFunctions.ClickAsync(Locators.AddTeamMember.DeleteUserbutton_Xpath);

        await Page.WaitForTimeoutAsync(3000);
        await BaseFunctions.ClickAsync(Locators.AddTeamMember.DeleteUserPop_UP_Xpath);
        await Page.WaitForTimeoutAsync(3000);

        await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.SearchTeamMembers_Xpath, teamMemberData.LastName);
        await Page.WaitForTimeoutAsync(3000);

        var isUserPresent = await Page.IsVisibleAsync(userRowXPath);
        Assert.IsFalse(isUserPresent, "The user was not deleted successfully.");
    }
}
