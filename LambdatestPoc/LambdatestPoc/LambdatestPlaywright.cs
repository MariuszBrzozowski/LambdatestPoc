using Microsoft.Playwright;

namespace LambdatestPoc;

[TestClass]
public class LambdatestPlaywright
{
    private const string User = "mariuszbrzozowski1985";
    private const string AccessKey = "zrZFS6epTfiG3xX61aMatNBVwiXLNtSKWgUOwpTrRk9wscgiU1";

    private const string TestUrl = "http://it.staging.shfydigital.com/";
    
    [TestMethod]
    [DataRow("Chrome")]
    [DataRow("MicrosoftEdge")]
    [DataRow("pw-chromium")]
    [DataRow("pw-webkit")]
    [DataRow("pw-firefox")]
    public async Task Playwright_Lambdatest_Windows11(string browserName)
    {
        using var playwright = await Playwright.CreateAsync();
        
        var ltOptions = new Dictionary<string, string>
        {
            { "user", User },
            { "accessKey", AccessKey },
            { "platformName", "Windows 11" },
            { "w3c", "true" },
            { "plugin", "c#-c#" },
            { "build", "Playwright_Lambdatest_POC" },
            { "name", $"Playwright_Lambdatest_Windows11 - {browserName}" }
        };
        
        var capabilities = new Dictionary<string, object>
        {
            { "browserName", browserName },
            { "browserVersion", "latest" },
            { "LT:Options", ltOptions }
        };

        var capabilitiesJson = JsonConvert.SerializeObject(capabilities);

        var cdpUrl = "wss://cdp.lambdatest.com/playwright?capabilities=" + Uri.EscapeDataString(capabilitiesJson);

        await using var browser = await playwright.Chromium.ConnectAsync(cdpUrl);
        await LambdatestPlaywrightPoc(browser);
    }
    
    [TestMethod]
    [DataRow("Chrome")]
    [DataRow("MicrosoftEdge")]
    [DataRow("pw-chromium")]
    [DataRow("pw-webkit")]
    [DataRow("pw-firefox")]
    public async Task Playwright_Lambdatest_MacOS(string browserName)
    {
        using var playwright = await Playwright.CreateAsync();
        
        var ltOptions = new Dictionary<string, string>
        {
            { "user", User },
            { "accessKey", AccessKey },
            { "platformName", "macOS Sonoma" },
            { "w3c", "true" },
            { "plugin", "c#-c#" },
            { "build", "Playwright_Lambdatest_POC" },
            { "name", $"Playwright_Lambdatest_MacOS - {browserName}" }
        };
        
        var capabilities = new Dictionary<string, object>
        {
            { "browserName", browserName },
            { "browserVersion", "latest" },
            { "LT:Options", ltOptions }
        };

        var capabilitiesJson = JsonConvert.SerializeObject(capabilities);

        var cdpUrl = "wss://cdp.lambdatest.com/playwright?capabilities=" + Uri.EscapeDataString(capabilitiesJson);

        await using var browser = await playwright.Chromium.ConnectAsync(cdpUrl);
        await LambdatestPlaywrightPoc(browser);
    }

    private static async Task LambdatestPlaywrightPoc(IBrowser browser)
    {
        var page = await browser.NewPageAsync();
        await page.GotoAsync(TestUrl);
        await Task.Delay(TimeSpan.FromSeconds(15));
    }
}