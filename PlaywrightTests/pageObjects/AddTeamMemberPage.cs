using Microsoft.Playwright;
using System.Threading.Tasks;

public class AddTeamMemberPage
{
    private readonly IPage _page;
    private readonly BaseFunctions _baseFunctions;

    public AddTeamMemberPage(IPage page)
    {
        _page = page;
        _baseFunctions = new BaseFunctions(_page); // Pass the page instance to BaseFunctions

    }

    public async Task ClickAddTeamMemberButton()
    {
        await _page.ClickAsync(Locators.SetupPage.AddTeamMemberButton);
    }

    public async Task SelectRoleDropdown(string roleValue)
    {
        await _page.ClickAsync(Locators.AddTeamMember.RoleDropdown_Xpath);
        await _page.SelectOptionAsync(Locators.AddTeamMember.RoleDropdown_Xpath, new[] { roleValue });
    }

    public async Task FillTeamMemberDetails(TeamMemberData data)
    {
        await _page.FillAsync(Locators.AddTeamMember.FirstName_Xpath, data.FirstName);
        await _page.FillAsync(Locators.AddTeamMember.LastName_Xpath, data.LastName);
        await _page.FillAsync(Locators.AddTeamMember.Email_Xpath, data.Email);
        await _page.FillAsync(Locators.AddTeamMember.Phone_Xpath, data.Phone);
        await _page.FillAsync(Locators.AddTeamMember.Username_Xpath, data.Username);
        await _page.FillAsync(Locators.AddTeamMember.Password_Xpath, data.Password);
        await _page.FillAsync(Locators.AddTeamMember.ConfirmPassword_Xpath, data.ConfirmPassword);
    }

    public async Task ClickSaveAndCloseButton()
    {
        await _page.ClickAsync(Locators.AddTeamMember.SaveAndCloseButton_Xpath);
    }

    public async Task<string> GetAlertMessageIfVisible()
    {
        if (await _page.IsVisibleAsync("//ngb-alert[@role='alert']"))
        {
            return await _page.TextContentAsync("//ngb-alert[@role='alert']");
        }
        return null;
    }

    public async Task<bool> IsTeamMemberSearchVisible()
    {
        return await _page.IsVisibleAsync("//input[@placeholder='Search team members']");
    }

    
    public async Task<bool> HandleAlertOrSuccessAsync(string alertSelector, string searchBoxSelector, string outputFilePath)
    {
        if (await _page.IsVisibleAsync(alertSelector))
        {
            string alertText = await _page.TextContentAsync(alertSelector);
            // Log the alert message
            Console.WriteLine($"Alert message displayed: {alertText}");
            
            // If the message contains "Saved", it means the operation was successful
            if (alertText.Contains("Saved", StringComparison.OrdinalIgnoreCase))
            {
                return true; // Success
            }
            else
            {
                // Log the error and save it in the output CSV file
                await File.AppendAllTextAsync(outputFilePath, $"Error: {alertText}\n");
                return false; // Failure
            }
        }
        
        await _page.WaitForTimeoutAsync(2000);
        
        // If the search box is visible, assume success
        if (await _page.IsVisibleAsync(searchBoxSelector))
        {
            return true; // Success
        }
        
        return false; // Failure
    }

    public async Task SearchForTeamMemberAsync(string searchBoxSelector, string lastName, string firstName, string Email)
    {
        string fullName = $"{lastName.ToLower()}, {firstName.ToLower()}".Trim();
        await _page.FillAsync(searchBoxSelector, lastName); // Search by last name
        await _page.PressAsync(searchBoxSelector, "Enter"); // Press enter to search
        await _page.WaitForTimeoutAsync(3000); // Wait for search results to load

        int rowIndex = 1;
        bool found = false;

while (true)
{
    // Get the XPath for the name and email in the current row
    var nameXpath = string.Format(Locators.AddTeamMember.TeamMemberRowColumn, rowIndex, 1);
    var emailXpath = string.Format(Locators.AddTeamMember.TeamMemberRowColumn, rowIndex, 3);

    // Check if the row is visible, if not, break the loop as there are no more rows
    if (await _baseFunctions.IsVisibleAsync(nameXpath))
    {
        // Retrieve and clean up the text from the name and email fields
        string nameInRow = (await _baseFunctions.GetTextAsync(nameXpath)).Trim().ToLower();
        string emailInRow = (await _baseFunctions.GetTextAsync(emailXpath)).Trim().ToLower();

        // Log the values for debugging purposes
        Console.WriteLine($"Checking row {rowIndex}: nameInRow='{nameInRow}', fullName='{fullName}', emailInRow='{emailInRow}', expectedEmail='{Email.Trim().ToLower()}'");

        // Check if both the name and email match the expected values
        if (nameInRow.Equals(fullName) && emailInRow.Equals(Email.Trim().ToLower()))
        {
            Console.WriteLine("Match found: name and email are correct.");
            found = true;
            break;
        }

        // Move to the next row
        rowIndex++;
    }
    else
    {
        break; // No more rows to check
    }
}

// Assert that the team member was found
if (!found)
{
    Assert.Fail($"Team member with name '{fullName}' and email '{Email}' not found in the search results.");
}


        

        Console.WriteLine("Team member data matches the expected values.");
    }

    public async Task EditUserDetailsAsync(string lastName, string firstName)
    {
        string rowXpath = GetRowXpath(lastName, firstName);
        string editButtonXpath = $"{rowXpath}/a[@role='link']";

        // Click on the edit button
        await _page.ClickAsync(editButtonXpath);

        // Modify the details
        await _page.FillAsync(Locators.AddTeamMember.FirstName_Xpath, $"{firstName}1");
        await _page.FillAsync(Locators.AddTeamMember.LastName_Xpath, $"{lastName}1");

        // Click Save and Close
        await _page.ClickAsync(Locators.AddTeamMember.SaveAndCloseButton_Xpath);

        // Add a wait if necessary
        await _page.WaitForTimeoutAsync(3000);
    }

    public async Task EditAndDeleteUserAsync(string lastName, string firstName)
    {
        string rowXpath = GetRowXpath(lastName, firstName);
        string editButtonXpath = $"{rowXpath}/a[@role='link']";
        string deleteButtonXpath = "(//button[@type='button'])[2]";

        // Click on the edit button
        await _page.ClickAsync(editButtonXpath);

        // Click the delete button
        await _page.ClickAsync(deleteButtonXpath);

        // Confirm deletion if necessary (assuming there's a confirmation dialog)
        // await _page.ClickAsync("//button[@class='btn-confirm']");

        // Add a wait if necessary
        await _page.WaitForTimeoutAsync(3000);
    }

    private string GetRowXpath(string lastName, string firstName)
    {
        return $"//tbody/tr[td[1][contains(text(), '{lastName}')] and td[2][contains(text(), '{firstName}')]]";
    }

}


