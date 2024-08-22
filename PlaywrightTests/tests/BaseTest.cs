using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;
using System;

public class BaseTest
{
    protected IPlaywright Playwright;
    protected IBrowser Browser;
    protected IPage Page;
    protected BaseFunctions BaseFunctions;
    protected string Username;
    protected string Password;

    [SetUp]
    public async Task BaseSetUp()
    {
        Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        Page = await Browser.NewPageAsync();
        BaseFunctions = new BaseFunctions(Page);

        // Read credentials
        (Username, Password) = ConfigReader.GetCredentials();
        Console.WriteLine($"Username: '{Username}', Password: '{Password}'"); // Debug log
    }

    [TearDown]
    public async Task BaseTearDown()
    {
        await Browser.CloseAsync();
        Playwright.Dispose();
    }

    protected async Task Login()
    {
        await Page.GotoAsync(Conftest.BaseURL);
        await BaseFunctions.SendKeysAsync(Locators.LoginPage.UsernameInput, Username);
        await BaseFunctions.SendKeysAsync(Locators.LoginPage.PasswordInput, Password);
        await BaseFunctions.ClickAsync(Locators.LoginPage.LoginButton);
        
        // Wait for the page to load after login
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);


        // Handle the pop-up
        await HandlePopUp();

        // Get the displayed username
        string displayedUsername = await Page.TextContentAsync(Locators.HomePage.UsernameDisplay);
        
        // Log the displayed username for debugging
        Console.WriteLine($"Displayed Username: '{displayedUsername}'");

        // Assert that the displayed username contains our expected username
        Assert.That(displayedUsername, Does.Contain(Username), $"Expected username '{Username}' not found in displayed text '{displayedUsername}'");
    }

    
    private async Task HandlePopUp()
    {
        try
        {
            // Wait for the pop-up to appear, but don't throw an error if it doesn't
            var popUpVisible = await Page.WaitForSelectorAsync(Locators.Popups.CloseButton, new PageWaitForSelectorOptions
            {
                State = WaitForSelectorState.Visible,
                Timeout = 5000 // Wait for 5 seconds max
            });

            // If the pop-up is visible, click the close button
            if (popUpVisible != null)
            {
                await BaseFunctions.ClickAsync(Locators.Popups.CloseButton);

                // Wait for the pop-up to disappear
                await Page.WaitForSelectorAsync(Locators.Popups.CloseButton, new PageWaitForSelectorOptions
                {
                    State = WaitForSelectorState.Hidden,
                    Timeout = 5000 // Wait for 5 seconds max
                });

                Console.WriteLine("Pop-up closed successfully");
            }
            else
            {
                Console.WriteLine("Pop-up did not appear, proceeding without closing it.");
            }
        }
        catch (TimeoutException)
        {
            Console.WriteLine("Pop-up did not appear within the timeout, proceeding without closing it.");
        }
    }

}