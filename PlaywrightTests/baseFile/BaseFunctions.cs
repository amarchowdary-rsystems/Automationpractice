using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

public class BaseFunctions
{
    private readonly IPage _page;

    public BaseFunctions(IPage page)
    {
        _page = page;
    }

    public async Task ClickAsync(string selector, int timeoutInSeconds = 30, int delayInMilliseconds = 500)
    {
    if (string.IsNullOrEmpty(selector))
    {
        Assert.Fail("Selector is null or empty.");
        return;
    }

    if (await WaitForElementAsync(selector, timeoutInSeconds, delayInMilliseconds))
    {
        await _page.ClickAsync(selector);
    }
    else
    {
        Assert.Fail($"Element with selector '{selector}' not found within {timeoutInSeconds} seconds.");
    }
    }

    public async Task SendKeysAsync(string selector, string? text, int timeoutInSeconds = 30, int delayInMilliseconds = 500)
    {
        if (string.IsNullOrEmpty(selector))
        {
            Assert.Fail("Selector is null or empty.");
            return;
        }
        
        if (text == null)
        {
            Assert.Fail("Text is null.");
            return;
        }

        if (await WaitForElementAsync(selector, timeoutInSeconds, delayInMilliseconds))
        {
            await _page.FillAsync(selector, text);
        }
        else
        {
            Assert.Fail($"Element with selector '{selector}' not found within {timeoutInSeconds} seconds.");
        }
    }



    public async Task<bool> IsVisibleAsync(string selector, int timeoutInSeconds = 30, int delayInMilliseconds = 500)
    {
    return await WaitForElementAsync(selector, timeoutInSeconds, delayInMilliseconds);
    }


    public async Task AssertTextContainsAsync(string selector, string expectedText)
    {
        var actualText = await _page.TextContentAsync(selector);
        Assert.That(actualText, Does.Contain(expectedText));
    }

    public async Task<bool> WaitForElementAsync(string selector, int timeoutInSeconds = 30, int delayInMilliseconds = 500)
    {
    var endTime = DateTime.Now.AddSeconds(timeoutInSeconds);
    while (DateTime.Now < endTime)
    {
        var element = await _page.QuerySelectorAsync(selector);
        if (element != null && await element.IsVisibleAsync())
        {
            return true;
        }
        await Task.Delay(delayInMilliseconds);
    }
    return false;
    }
    public async Task SelectOptionAsync(string dropdownSelector, string optionValue, int timeoutInSeconds = 30)
    {
    // Print values for debugging
    Console.WriteLine($"Attempting to select option from dropdown with selector: {dropdownSelector}");
    Console.WriteLine($"Option value to select: {optionValue}");

    // Wait for the dropdown to be visible
    if (await WaitForElementAsync(dropdownSelector, timeoutInSeconds))
    {
        // Print confirmation that dropdown is found
        Console.WriteLine($"Dropdown with selector '{dropdownSelector}' found. Selecting option '{optionValue}'.");

        // Select the option from the dropdown
        await _page.SelectOptionAsync(dropdownSelector, new[] { optionValue });
        
        // Print confirmation that option was selected
        Console.WriteLine($"Successfully selected option with value '{optionValue}' from dropdown.");
    }
    else
    {
        // Print error message if dropdown is not found
        Console.WriteLine($"Dropdown with selector '{dropdownSelector}' not found within {timeoutInSeconds} seconds.");
        Assert.Fail($"Dropdown with selector '{dropdownSelector}' not found within {timeoutInSeconds} seconds.");
    }
    }

    public async Task<string> CheckForAlertAndHandleAsync(string alertSelector, string searchBoxSelector, int timeoutInSeconds = 60)
    {
    Console.WriteLine("Checking for alert or success indicator...");
    
    if (await _page.IsVisibleAsync(alertSelector, new PageIsVisibleOptions { Timeout = timeoutInSeconds * 1000 }))
    {
        var alertText = await _page.TextContentAsync(alertSelector);
        Console.WriteLine($"Alert found: {alertText}");
        await File.AppendAllTextAsync("output.csv", $"{alertText}\n"); // Save to CSV
        Assert.Fail($"Error during team member creation: {alertText}");
        return alertText;
    }
    else if (await _page.IsVisibleAsync(searchBoxSelector, new PageIsVisibleOptions { Timeout = timeoutInSeconds * 1000 }))
    {
        Console.WriteLine("Team member created successfully.");
        return null;
    }
    else
    {
        Console.WriteLine("No alert or success indicator found after submission.");
        Assert.Fail("Neither alert nor success indicator was found.");
        return null;
    }
    }
    public async Task<string> GetTextAsync(string selector)
    {
        try
        {
            return await _page.TextContentAsync(selector);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to get text from selector {selector}: {ex.Message}");
            return string.Empty;
        }
    }




}