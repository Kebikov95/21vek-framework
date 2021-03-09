using AutomationFramework.Main.Framework.Browser;
using NLog.Fluent;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationFramework.Main.Framework.UI.Components
{
    class CommonPageElement
    {
        private static string TimeoutErrorMessage = "Invalid timeout: Timeout in seconds cannot be less than 0.";
        protected static string LocatorErrorMessage = "Invalid locator: Locator cannot be null.";
        private static string AttributeErrorMessage = "Invalid attribut: Attribute cannot be null.";
        private static int TimeoutInSeconds = 10;
        private static int PoolingEveryMilliseconds = 500;
        private static IWebDriver WrappedDriver = BrowserManager.GetInstance().WrappedDriver;
        protected By by;

        public CommonPageElement(By by)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            this.by = by;
        }

        private static DefaultWait<IWebDriver> GetCustomWait(int timeoutInSeconds)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(WrappedDriver);
            fluentWait.Timeout = TimeSpan.FromSeconds(timeoutInSeconds);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(PoolingEveryMilliseconds);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            fluentWait.Message = "Element to be searched not found";
            return fluentWait;
        }

        public static String GetAttribute(By by, String attribute)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            if (attribute == null) throw new ArgumentNullException(AttributeErrorMessage);
            WaitForElementExists(by);
            IWebElement element = WrappedDriver.FindElement(by);
            return element.GetAttribute(attribute).Trim();
        }

        public static void WaitForElementExists(By by)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            WaitForElementExists(by, TimeoutInSeconds);
        }

        public static void WaitForElementExists(By by, int timeoutInSeconds)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            if (timeoutInSeconds < 0) throw new ArgumentNullException(TimeoutErrorMessage);
            DefaultWait<IWebDriver> wait = GetCustomWait(timeoutInSeconds);
            wait.Until(ExpectedConditions.ElementExists(by));
        }

        public static void WaitForElementIsVisible(By by)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            WaitForElementIsVisible(by, TimeoutInSeconds);
        }

        public static void WaitForElementIsVisible(By by, int timeoutInSeconds)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            if (timeoutInSeconds < 0) throw new ArgumentNullException(TimeoutErrorMessage);
            DefaultWait<IWebDriver> wait = GetCustomWait(timeoutInSeconds);
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public static void WaitForVisibilityOfAllElementsLocatedBy(By by)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            WaitForVisibilityOfAllElementsLocatedBy(by, TimeoutInSeconds);
        }

        public static void WaitForVisibilityOfAllElementsLocatedBy(By by, int timeoutInSeconds)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            if (timeoutInSeconds < 0) throw new ArgumentNullException(TimeoutErrorMessage);
            DefaultWait<IWebDriver> wait = GetCustomWait(timeoutInSeconds);
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
        }

        public static void WaitForInvisibilityOfElementLocated(By by)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            WaitForInvisibilityOfElementLocated(by, TimeoutInSeconds);
        }

        public static void WaitForInvisibilityOfElementLocated(By by, int timeoutInSeconds)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            if (timeoutInSeconds < 0) throw new ArgumentNullException(TimeoutErrorMessage);
            DefaultWait<IWebDriver> wait = GetCustomWait(timeoutInSeconds);
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }

        public static void WaitForPresenceOfAllElementsLocatedBy(By by)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            WaitForPresenceOfAllElementsLocatedBy(by, TimeoutInSeconds);
        }

        public static void WaitForPresenceOfAllElementsLocatedBy(By by, int timeoutInSeconds)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            if (timeoutInSeconds < 0) throw new ArgumentNullException(TimeoutErrorMessage);
            DefaultWait<IWebDriver> wait = GetCustomWait(timeoutInSeconds);
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
        }

        public static void WaitForElementToBeClickable(By by)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            WaitForElementToBeClickable(by, TimeoutInSeconds);
        }

        public static void WaitForElementToBeClickable(By by, int timeoutInSeconds)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            if (timeoutInSeconds < 0) throw new ArgumentNullException(TimeoutErrorMessage);
            DefaultWait<IWebDriver> wait = GetCustomWait(timeoutInSeconds);
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public static bool IsElementVisible(By by, int timeoutInSeconds = 10)
        {
            if (by == null) throw new ArgumentNullException(LocatorErrorMessage);
            if (timeoutInSeconds < 0) throw new ArgumentNullException(TimeoutErrorMessage);
            try
            {
                WaitForElementIsVisible(by, timeoutInSeconds);
                return true;
            }
            catch (TimeoutException)
            {
                Log.Info("No such element found on current page.");
                return false;
            }
        }
    }
}
