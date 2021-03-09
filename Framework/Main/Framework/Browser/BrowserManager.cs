using AutomationFramework.Main.Framework.UI.Elements;
using Framework.Main.Framework.Browser;
using NLog.Fluent;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationFramework.Main.Framework.Browser
{
    class BrowserManager : IWrapsDriver
    {
        private static ThreadLocal<BrowserManager> Instance = new ThreadLocal<BrowserManager>();
        private static IWebDriver wrappedDriver;
        private readonly string ScreenshotDirectoryPath = @"..\..\..\..\Framework\Resources\Screenshots";
        private static readonly string LocatorErrorMessage = "Invalid locator: Locator cannot be null.";

        public IWebDriver WrappedDriver => wrappedDriver;

        private BrowserManager()
        {
            wrappedDriver = WebDriverFactory.GetWebDriver(BrowserTypes.Chrome);
            wrappedDriver.Manage().Window.Maximize();
            Log.Debug("Creating instance of WebDriver with ChromeDriver.");
        }

        public static BrowserManager GetInstance()
        {
            Log.Debug("Getting instance of browser.");
            if (Instance.Value == null) Instance.Value = new BrowserManager();
            return Instance.Value;
        }

        public static void Stop()
        {
            Log.Debug("Stopping the browser.");
            try
            {
                if (Instance != null) Instance.Value.WrappedDriver.Quit();
            }
            finally
            {
                Instance.Dispose();
            }
        }

        public void ScrollBy(int p1, int p2)
        {
            string script = string.Format("window.scrollBy({0}, {1})", p1, p2);
            IWebDriver driver = BrowserManager.GetInstance().WrappedDriver;
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("window.scrollBy(0,1000)");
            Log.Debug(string.Format("Scroll window by ({0}, {1})", p1, p2));
        }

        public void Refresh()
        {
            BrowserManager.GetInstance().WrappedDriver.Navigate().Refresh();
        }

        public void NavigateToUrl(string url)
        {
            if (url == null) throw new ArgumentNullException("Invalid URL: URL cannot be null.");
            Log.Debug("Navigating to " + url);
            wrappedDriver.Navigate().GoToUrl(url);
        }

        public void Click(By by)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            Log.Debug("Click on " + by);
            IWebElement element = wrappedDriver.FindElement(by);
            HighlightedWebElement highlightedWebElement = new HighlightedWebElement(wrappedDriver, element);
            highlightedWebElement.Click();
        }

        public void SendKeys(By by, string text)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            if (text == null) throw new ArgumentNullException("Invalid Text: Text cannot be null.");
            Log.Debug("Send keys " + text + " to " + by);
            IWebElement element = wrappedDriver.FindElement(by);
            HighlightedWebElement highlightedWebElement = new HighlightedWebElement(wrappedDriver, element);
            highlightedWebElement.SendKeys(text);
        }

        public void Submit(By by)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            Log.Debug("Submit to " + by);
            IWebElement element = wrappedDriver.FindElement(by);
            HighlightedWebElement highlightedWebElement = new HighlightedWebElement(wrappedDriver, element);
            highlightedWebElement.Submit();
        }

        public void Clear(By by)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            Log.Debug("Clearing field " + by);
            IWebElement element = wrappedDriver.FindElement(by);
            HighlightedWebElement highlightedWebElement = new HighlightedWebElement(wrappedDriver, element);
            highlightedWebElement.Clear();
        }

        public string GetText(By by)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            Log.Debug("Getting the text of WebElement located by " + by);
            IWebElement element = wrappedDriver.FindElement(by);
            HighlightedWebElement highlightedWebElement = new HighlightedWebElement(wrappedDriver, element);
            return highlightedWebElement.Text.Trim();
        }

        public bool IsSelected(By by)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            IWebElement element = wrappedDriver.FindElement(by);
            return element.Selected;
        }

        public void Select(By by, string option)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            if (option == null) throw new ArgumentNullException("Invalid Option: Option cannot be null.");
            Log.Debug("Selecting option item - " + option);
            Click(by);
            IWebElement element = wrappedDriver.FindElement(by);
            HighlightedWebElement highlightedWebElement = new HighlightedWebElement(wrappedDriver, element);
            SelectElement dropDownList = new SelectElement(highlightedWebElement);
            dropDownList.SelectByText(option);
        }
    }
}
