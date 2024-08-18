namespace AAUPG_JasnaPTrivunovic.POMs
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using TechTalk.SpecFlow;

    [Binding]
    public class BasePage
    {
        public static IWebDriver Driver;
        public static DefaultWait<IWebDriver> Wait;

        [BeforeScenario]
        public static void InitializeDriver()
        {
            Driver = CreateChromeDriver();
            Wait = new DefaultWait<IWebDriver>(Driver);
            Wait.Timeout = TimeSpan.FromSeconds(5);
            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
            Wait.PollingInterval = TimeSpan.FromMilliseconds(100);
        }

        [AfterScenario]
        public static void QuitDriver()
        {
            Driver.Quit();
        }

        public static IWebDriver CreateChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--enable-javascript");
            options.AddArguments("disable-infobars");
            options.AddExcludedArgument("enable-automation");
            options.AddArguments("--disable-notifications");

            IWebDriver chromeDriver = new ChromeDriver(options);
            chromeDriver.Manage().Window.Maximize();

            return chromeDriver;
        }

        public bool IsUrlContaining(string urlPart)
        {
            string currentUrl = Driver.Url;
            return currentUrl.Contains(urlPart);
        }

        public void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript(@"
                var element = arguments[0];
                var elementPosition = element.getBoundingClientRect().top + window.pageYOffset;
                var offset = window.innerHeight / 2 - element.clientHeight / 2;
                window.scrollTo({ top: elementPosition - offset, behavior: 'smooth' });
            ", element);
        }
    }
}