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
    if (await WaitForElementAsync(selector, timeoutInSeconds, delayInMilliseconds))
    {
        await _page.ClickAsync(selector);
    }
    else
    {
        Assert.Fail($"Element with selector '{selector}' not found within {timeoutInSeconds} seconds.");
    }
}

public async Task SendKeysAsync(string selector, string text, int timeoutInSeconds = 30, int delayInMilliseconds = 500)
{
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

}