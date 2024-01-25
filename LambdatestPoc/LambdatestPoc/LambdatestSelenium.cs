using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;

namespace LambdatestPoc;

[TestClass]
public class LambdatestSelenium
{
    private const string User = "";
    private const string AccessKey = "";
    
    private const string Hub = "https://hub.lambdatest.com/wd/hub/";
    private const string MobileHub = "https://mobile-hub.lambdatest.com/wd/hub";
    
    private const string TestUrl = "";
    
    [TestMethod]
    [DataRow(Common.Browser.Chrome, Common.OperationSystem.Windows)]
    [DataRow(Common.Browser.Firefox, Common.OperationSystem.Windows)]
    [DataRow(Common.Browser.Edge, Common.OperationSystem.Windows)]
    [DataRow(Common.Browser.Safari, Common.OperationSystem.Windows)]
    [DataRow(Common.Browser.Chrome, Common.OperationSystem.MacOS)]
    [DataRow(Common.Browser.Firefox, Common.OperationSystem.MacOS)]
    [DataRow(Common.Browser.Edge, Common.OperationSystem.MacOS)]
    [DataRow(Common.Browser.Safari, Common.OperationSystem.MacOS)]
    [DataRow(Common.Browser.Chrome, Common.OperationSystem.Android)]
    [DataRow(Common.Browser.Firefox, Common.OperationSystem.Android)]
    [DataRow(Common.Browser.Edge, Common.OperationSystem.Android)]
    [DataRow(Common.Browser.Safari, Common.OperationSystem.Android)]
    [DataRow(Common.Browser.Chrome, Common.OperationSystem.IOS)]
    [DataRow(Common.Browser.Firefox, Common.OperationSystem.IOS)]
    [DataRow(Common.Browser.Edge, Common.OperationSystem.IOS)]
    [DataRow(Common.Browser.Safari, Common.OperationSystem.IOS)]
    public void Selenium_Lambdatest_iOS(Common.Browser browser, Common.OperationSystem operationSystem)
    {
        var driver = new RemoteWebDriver(new Uri(GetHub(operationSystem)), GetSeleniumCapabilities(browser, GetLtOptions(operationSystem)));
        Trace.WriteLine(driver.Capabilities.ToString());
        LambdatestSeleniumPocTestFlow(driver);
    }

    private static void LambdatestSeleniumPocTestFlow(WebDriver driver)
    {
        driver.Url = TestUrl;
        Thread.Sleep(TimeSpan.FromSeconds(15));
        driver.Quit();
    }

    private static dynamic GetSeleniumCapabilities(Common.Browser browserType, Dictionary<string, object> ltOptions)
    {
        var capabilities = GetBrowserOptions(browserType);
        capabilities.AddAdditionalOption("LT:Options", ltOptions);
        return capabilities;
    }

    private static dynamic GetBrowserOptions(Common.Browser browserType)
    {
        return browserType switch
        {
            Common.Browser.Chrome => new ChromeOptions { BrowserVersion = "latest" },
            Common.Browser.Edge => new EdgeOptions { BrowserVersion = "latest" },
            Common.Browser.Firefox => new FirefoxOptions { BrowserVersion = "latest" },
            Common.Browser.Safari => new SafariOptions { BrowserVersion = "latest" },
            _ => null!
        };
    }
    
    private static Dictionary<string, object> GetLtOptions(Common.OperationSystem operationSystem)
    {
        return operationSystem switch
        {
            Common.OperationSystem.Windows => WindowsLtOptions(),
            Common.OperationSystem.MacOS => MacOSLtOptions(),
            Common.OperationSystem.Android => AndroidLtOptions(),
            Common.OperationSystem.IOS => IOSLtOptions(),
            _ => null!
        };
    }

    private static string GetHub(Common.OperationSystem operationSystem) => operationSystem switch
    {
        Common.OperationSystem.Windows => Hub,
        Common.OperationSystem.MacOS => Hub,
        Common.OperationSystem.Android => MobileHub,
        Common.OperationSystem.IOS => MobileHub,
        _ => string.Empty
    };

    private static Dictionary<string, object> AndroidLtOptions() => new()
    {
        { "user", User },
        { "accessKey", AccessKey },
        { "deviceName", "Galaxy S21 Ultra 5G" },
        { "platformVersion", "11"},
        { "platformName", "Android"},
        { "isRealMobile", true},
        { "network", false},
        { "project", "Selenium_Lambdatest" },
        { "build", "Selenium_Lambdatest" },
        { "sessionName", "Selenium_Lambdatest_Android" },
        { "w3c", true },
        { "plugin", "c#-c#" }
    };
    
    private static Dictionary<string, object> IOSLtOptions() => new()
    {
        { "user", User },
        { "accessKey", AccessKey },
        { "deviceName", "iPhone 12" },
        { "platformVersion", "15"},
        { "platformName", "iOS"},
        { "isRealMobile", true},
        { "network", false},
        { "project", "Selenium_Lambdatest" },
        { "build", "Selenium_Lambdatest" },
        { "sessionName", "Selenium_Lambdatest_iOS" },
        { "w3c", true },
        { "plugin", "c#-c#" }
    };
    
    private static Dictionary<string, object> WindowsLtOptions() => new()
    {
        { "username", User },
        { "accessKey", AccessKey },
        { "platformName", "Windows 11" },
        { "project", "Selenium_Lambdatest" },
        { "build", "Selenium_Lambdatest" },
        { "sessionName", "Selenium_Lambdatest_Windows11" },
        { "w3c", true },
        { "plugin", "c#-c#" }
    };
    
    private static Dictionary<string, object> MacOSLtOptions() => new()
    {
        { "username", User },
        { "accessKey", AccessKey },
        { "platformName", "Monterey" },
        { "project", "Selenium_Lambdatest" },
        { "build", "Selenium_Lambdatest" },
        { "sessionName", "Selenium_Lambdatest_MacOS" },
        { "w3c", true },
        { "plugin", "c#-c#" }
    };
}