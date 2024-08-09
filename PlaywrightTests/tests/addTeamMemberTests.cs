// [TestFixture]
// public class AddTeamMemberTests : BaseTest
// {
//     private TeamMemberData _testData;
//     private (string RoleValue, string TeacherTypeValue) _dropdownValues;

//     [SetUp]
//     public void SetUp()
//     {
//         _testData = ConfigReader.GetTeamMemberData() ?? throw new InvalidOperationException("Test data is null.");
//         _dropdownValues = ConfigReader.GetDropdownValues();
//     }

//     [Test]
//     public async Task AddNewTeamMember()
//     {
//         // Login and navigate to the "Manage Team Members" page
//         await Login();
//         await BaseFunctions.ClickAsync(Locators.HomePage.SetupLink);
//         await BaseFunctions.AssertTextContainsAsync(Locators.SetupPage.PageTitle, "Setup");
//         await BaseFunctions.ClickAsync(Locators.SetupPage.ManageTeamMembersLink);

//         // Click the "Add Team Member" button
//         await BaseFunctions.ClickAsync(Locators.SetupPage.AddTeamMemberButton);

//         // Select the role from the dropdown
//         await BaseFunctions.SelectOptionAsync(Locators.AddTeamMember.RoleDropdown_Xpath, _testData.RoleValue);


//         // Enter the team member details
//         await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.FirstName_Xpath, _testData.FirstName);
//         await Task.Delay(1000); // 1-second delay
//         await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.LastName_Xpath, _testData.LastName);
//         await Task.Delay(1000); // 1-second delay
//         await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.Email_Xpath, _testData.Email);
//         await Task.Delay(1000); // 1-second delay
//         //await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.Phone_Xpath, _testData.Phone);
//         await Task.Delay(1000); // 1-second delay
//         await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.Username_Xpath, _testData.Username);
//         await Task.Delay(1000); // 1-second delay
//         await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.Password_Xpath, _testData.Password);
//         await Task.Delay(1000); // 1-second delay
//         await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.ConfirmPassword_Xpath, _testData.ConfirmPassword);
//         await Task.Delay(5000); // 5-second delay

//         // Click the "Save and Close" button
//         await BaseFunctions.ClickAsync(Locators.AddTeamMember.SaveAndCloseButton_Xpath);
        
        
        
//         // Verify that the "Assign Students" button is visible
// //         Assert.IsTrue(await BaseFunctions.IsVisibleAsync(Locators.AddTeamMember.AssignStudentsButton_Xpath));

// //         // Select the teacher type from the dropdown
// //         await BaseFunctions.ClickAsync(Locators.AddTeamMember.TeacherTypeDropdown_Xpath);
// //         await BaseFunctions.ClickAsync($"//option[@value='{_testData.TeacherTypeValue}']");

// //         // Verify the "Available Students" text
// //         await BaseFunctions.AssertTextContainsAsync(Locators.AddTeamMember.AvailableStudentsText_Xpath, "Available Students");
// //     }
// }

// }

[TestFixture]
public class AddTeamMemberTests : BaseTest
{

    private TeamMemberData _testData;
    private (string RoleValue, string TeacherTypeValue) _dropdownValues;

    [SetUp]
    public void SetUp()
    {
        //_testData = ConfigReader.GetTeamMemberData() ?? throw new InvalidOperationException("Test data is null.");
        _dropdownValues = ConfigReader.GetDropdownValues();
    }

    // [Test]
    // public async Task AddNewTeamMember()
    // {
    //     var addTeamMemberPage = new AddTeamMemberPage(Page);
    //     // Login and navigate to the "Manage Team Members" page
    //     await Login();
    //     await BaseFunctions.ClickAsync(Locators.HomePage.SetupLink);
    //     await BaseFunctions.AssertTextContainsAsync(Locators.SetupPage.PageTitle, "Setup");
    //     await BaseFunctions.ClickAsync(Locators.SetupPage.ManageTeamMembersLink);
    //     await BaseFunctions.ClickAsync(Locators.SetupPage.AddTeamMemberButton);

    //     // Select the role from the dropdown
    //     await BaseFunctions.SelectOptionAsync(Locators.AddTeamMember.RoleDropdown_Xpath, _testData.RoleValue);

    //     // Enter the team member details
    //     await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.FirstName_Xpath, _testData.FirstName);
    //     await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.LastName_Xpath, _testData.LastName);
    //     await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.Email_Xpath, _testData.Email);
    //     //await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.Phone_Xpath, _testData.Phone);
    //     await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.Username_Xpath, _testData.Username);
    //     await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.Password_Xpath, _testData.Password);
    //     await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.ConfirmPassword_Xpath, _testData.ConfirmPassword);

    //     // Click the "Save and Close" button
    //     await BaseFunctions.ClickAsync(Locators.AddTeamMember.SaveAndCloseButton_Xpath);
        
    //     // Add a wait to ensure the page has time to process the submission
    //     await Page.WaitForTimeoutAsync(3000);  // Wait for 3 seconds or more if necessary

    //     // Handle alert or success message
    //     await addTeamMemberPage.HandleAlertOrSuccessAsync(Locators.AddTeamMember.Alert_Xpath, Locators.AddTeamMember.SearchTeamMembers_Xpath, "output.csv");

    //     await Page.WaitForTimeoutAsync(3000);  // Wait for 3 seconds or more if necessary

    //     // Search for the newly added team member and verify the data
    //     await addTeamMemberPage.SearchForTeamMemberAsync(Locators.AddTeamMember.SearchTeamMembers_Xpath, _testData.LastName, _testData.FirstName, _testData.Email);

    //     // Check for alert or success
    //     //await BaseFunctions.CheckForAlertAndHandleAsync(Locators.AddTeamMember.Alert_Xpath, Locators.AddTeamMember.SearchTeamMembers_Xpath);
    // }
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
                continue; // Skip the rest of the test
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

    [Test]
public async Task EditUserData()
{
    // Get the previously added team member data
    var teamMemberData = ConfigReader.GetTeamMemberData();
    var addTeamMemberPage = new AddTeamMemberPage(Page);

    // Perform login
    await Login();
    await BaseFunctions.ClickAsync(Locators.HomePage.SetupLink);
    await BaseFunctions.AssertTextContainsAsync(Locators.SetupPage.PageTitle, "Setup");
    await BaseFunctions.ClickAsync(Locators.SetupPage.ManageTeamMembersLink);
    // await BaseFunctions.ClickAsync(Locators.AddTeamMember.SearchTeamMembers_Xpath);
    await Page.WaitForTimeoutAsync(3000); // Wait for search results to appear
    await Page.ReloadAsync();
    await BaseFunctions.ClickAsync(Locators.AddTeamMember.SearchTeamMembers_Xpath);
    // Search for the previously added team member
    await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.SearchTeamMembers_Xpath, teamMemberData.LastName);
    await Page.PressAsync(Locators.AddTeamMember.SearchTeamMembers_Xpath, "Enter");
    await Page.WaitForTimeoutAsync(5000); // Wait for search results to appear

    // Click on the respective user row
    var userRowXPath = $"//tbody/tr[1]/td[5]/a[@role='link']";
    await BaseFunctions.ClickAsync(userRowXPath);

    // Wait for the user details to load
    await Page.WaitForTimeoutAsync(3000);

    // Edit user details
    var editFirstNameXPath = Locators.AddTeamMember.FirstName_Xpath;
    var editLastNameXPath = Locators.AddTeamMember.LastName_Xpath;

    await BaseFunctions.SendKeysAsync(editFirstNameXPath, $"{teamMemberData.FirstName}1");
    await BaseFunctions.SendKeysAsync(editLastNameXPath, $"{teamMemberData.LastName}1");

    // Save and Close
    await BaseFunctions.ClickAsync(Locators.AddTeamMember.SaveAndCloseButton_Xpath);

    // Handle alert or success message
    await addTeamMemberPage.HandleAlertOrSuccessAsync(Locators.AddTeamMember.Alert_Xpath, Locators.AddTeamMember.SearchTeamMembers_Xpath, "output.csv");

    // Verify the edited data
    await Page.WaitForTimeoutAsync(3000); // Wait for the page to refresh
    await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.SearchTeamMembers_Xpath, $"{teamMemberData.LastName}1");
    await Page.WaitForTimeoutAsync(5000); // Wait for search results to appear

    // Click on the respective user row to verify
    await BaseFunctions.ClickAsync(userRowXPath);

    // Check the updated details
    string updatedFirstName = await Page.InputValueAsync(editFirstNameXPath);
    string updatedLastName = await Page.InputValueAsync(editLastNameXPath);

    Assert.That(updatedFirstName, Is.EqualTo($"{teamMemberData.FirstName}1"));
    Assert.That(updatedLastName, Is.EqualTo($"{teamMemberData.LastName}1"));
}

[Test]
public async Task DeleteUserData()
{
    // Get the previously added team member data
    var teamMemberData = ConfigReader.GetTeamMemberData();

    // Perform login
    await Login();
    await BaseFunctions.ClickAsync(Locators.HomePage.SetupLink);
    await BaseFunctions.AssertTextContainsAsync(Locators.SetupPage.PageTitle, "Setup");
    await BaseFunctions.ClickAsync(Locators.SetupPage.ManageTeamMembersLink);
    await Page.WaitForTimeoutAsync(5000); // Wait for search results to appear

    await Page.ReloadAsync();
    await BaseFunctions.ClickAsync(Locators.AddTeamMember.SearchTeamMembers_Xpath);
    // Search for the previously added team member
    await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.SearchTeamMembers_Xpath, teamMemberData.LastName);
    await Page.WaitForTimeoutAsync(5000); // Wait for search results to appear

    // Click on the respective user row
    var userRowXPath = $"//tbody/tr[1]/td[5]/a[@role='link']";
    await BaseFunctions.ClickAsync(userRowXPath);

    // Wait for the user details to load
    await Page.WaitForTimeoutAsync(5000); // Wait for search results to appear

    // await BaseFunctions.ClickAsync(Locators.AddTeamMember.EditButton_Xpath);

    // Click on Delete
    await BaseFunctions.ClickAsync(Locators.AddTeamMember.DeleteUserbutton_Xpath); // Assuming this is the delete button

    // await BaseFunctions.ClickAsync(Locators.DeleteConfirmationButton_Xpath);

    // Verify deletion
    await Page.WaitForTimeoutAsync(3000); // Wait for the page to refresh
    await BaseFunctions.ClickAsync(Locators.AddTeamMember.DeleteUserPop_UP_Xpath);
    await Page.WaitForTimeoutAsync(3000); // Wait for search results to appear
    await BaseFunctions.SendKeysAsync(Locators.AddTeamMember.SearchTeamMembers_Xpath, teamMemberData.LastName);
    await Page.WaitForTimeoutAsync(3000); // Wait for search results to appear

    // Verify the team member has been deleted
    var isUserPresent = await Page.IsVisibleAsync(userRowXPath);
    Assert.IsFalse(isUserPresent, "The user was not deleted successfully.");
}


}
