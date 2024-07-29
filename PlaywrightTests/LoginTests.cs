using NUnit.Framework;
using System.Threading.Tasks;
using System;

[TestFixture]
public class LoginTests : BaseTest
{
    [Test]
    public async Task LoginAndNavigateToManageTeamMembers()
    {
        await Login();

        // Add a short wait to ensure everything has settled
        await Task.Delay(2000);

        Console.WriteLine("Login successful, navigating to Setup");

        // Navigate to Setup
        await BaseFunctions.ClickAsync(Locators.HomePage.SetupLink);

        Console.WriteLine("Clicked Setup, asserting page title");

        // Assert Setup page
        await BaseFunctions.AssertTextContainsAsync(Locators.SetupPage.PageTitle, "Setup");

        Console.WriteLine("Setup page confirmed, navigating to Manage Team Members");

        // Navigate to Manage Team Members
        await BaseFunctions.ClickAsync(Locators.SetupPage.ManageTeamMembersLink);

        Console.WriteLine("Clicked Manage Team Members, asserting Add Team Member button visibility");

        // Assert Add Team Member button is visible
        Assert.IsTrue(await BaseFunctions.IsVisibleAsync(Locators.SetupPage.AddTeamMemberButton));

        Console.WriteLine("Test completed successfully");
    }
}