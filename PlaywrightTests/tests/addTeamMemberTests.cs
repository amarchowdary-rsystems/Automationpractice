[TestFixture]
public class AddTeamMemberTests : BaseTest
{
    private TeamMemberData _testData;
    private (string RoleValue, string TeacherTypeValue) _dropdownValues;

    [SetUp]
    public void SetUp()
    {
        _dropdownValues = ConfigReader.GetDropdownValues();
    }

    [Test]
    public async Task AddNewTeamMember()
    {
        var addTeamMemberPage = new AddTeamMemberPage(Page);

        // Get all test data rows
        var allTestData = ConfigReader.GetAllTeamMemberData();

        foreach (var testData in allTestData)
        {
            _testData = testData;

            // Login and navigate to the "Manage Team Members" page
            await Login();
            await BaseFunctions.ClickAsync(Locators.HomePage.SetupLink);
            await BaseFunctions.AssertTextContainsAsync(Locators.SetupPage.PageTitle, "Setup");
            await BaseFunctions.ClickAsync(Locators.SetupPage.ManageTeamMembersLink);
            await BaseFunctions.ClickAsync(Locators.SetupPage.AddTeamMemberButton);

            // Select the role from the dropdown
            await BaseFunctions.SelectOptionAsync(Locators.AddTeamMember.RoleDropdown_Xpath, _testData.RoleValue);

            // Enter the team member details
            await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.FirstName_Xpath, _testData.FirstName);
            await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.LastName_Xpath, _testData.LastName);
            await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.Email_Xpath, _testData.Email);
            await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.Username_Xpath, _testData.Username);
            await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.Password_Xpath, _testData.Password);
            await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.ConfirmPassword_Xpath, _testData.ConfirmPassword);

            // Click the "Save and Close" button
            await BaseFunctions.ClickAsync(Locators.AddTeamMember.SaveAndCloseButton_Xpath);

            // Handle alert or success message
            bool isSuccess = await addTeamMemberPage.HandleAlertOrSuccessAsync(Locators.AddTeamMember.Alert_Xpath, Locators.AddTeamMember.SearchTeamMembers_Xpath, "output.csv");

            // Check if the expected result matches the actual result
            if (_testData.ExpectedResult.Equals("Fail", StringComparison.OrdinalIgnoreCase) && !isSuccess)
            {
                Console.WriteLine("Test passed: Failure was expected and occurred.");
                continue;
            }
            else if (_testData.ExpectedResult.Equals("Pass", StringComparison.OrdinalIgnoreCase) && isSuccess)
            {
                Console.WriteLine("Test passed: Success was expected and occurred.");
                await addTeamMemberPage.SearchForTeamMemberAsync(Locators.AddTeamMember.SearchTeamMembers_Xpath, _testData.LastName, _testData.FirstName, _testData.Email);
            }
            else
            {
                Assert.Fail("Test failed: The actual result did not match the expected result.");
            }
        }
    }
}
