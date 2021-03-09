using NLog.Fluent;
using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using System.Drawing;

namespace AutomationFramework.Main.Framework.UI.Elements
{
    class HighlightedWebElement : IWebElement
    {
        private readonly IWebDriver driver;
        private readonly IWebElement element;
        private readonly string BackgroundColor = "#FFBB00";

        public HighlightedWebElement(IWebDriver driver, IWebElement element)
        {
            if (driver == null) throw new ArgumentNullException("Invalid locator: WebDriver cannot be null");
            if (element == null) throw new ArgumentNullException("Invalid locator: WebElement cannot be null");
            this.driver = driver;
            this.element = element;
        }

        private void Highlight()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor) driver;
            executor.ExecuteScript(string.Format("arguments[0].style.backgroundColor = '{0}';", BackgroundColor), element);
        }

        public string TagName => element.TagName;

        public string Text => element.Text;

        public bool Enabled => element.Enabled;

        public bool Selected => element.Selected;

        public Point Location => element.Location;

        public Size Size => element.Size;

        public bool Displayed => element.Displayed;

        Point IWebElement.Location => throw new NotImplementedException();

        Size IWebElement.Size => throw new NotImplementedException();

        public void Clear()
        {
            Highlight();
            element.Clear();
        }

        public void Click()
        {
            Highlight();
            element.Click();
        }

        public IWebElement FindElement(By by)
        {
            if (by == null) throw new ArgumentNullException("Invalid locator: Locator cannot be null.");
            return element.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            if (by == null) throw new ArgumentNullException("Invalid locator: Locator cannot be null.");
            return element.FindElements(by);
        }

        public string GetAttribute(string attributeName)
        {
            if (attributeName == null) throw new ArgumentNullException("Invalid attribut: Attribute cannot be null.");
            return element.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            if (propertyName == null) throw new ArgumentNullException("Invalid keys: Property name cannot be null.");
            return element.GetCssValue(propertyName);
        }

        public string GetProperty(string propertyName)
        {
            if (propertyName == null) throw new ArgumentNullException("Invalid keys: Property name cannot be null.");
            return element.GetProperty(propertyName);
        }

        public void SendKeys(string text)
        {
            if (text == null) throw new ArgumentNullException("Invalid keys: Text cannot be null.");
            Highlight();
            element.SendKeys(text);
        }

        public void Submit()
        {
            Highlight();
            element.Submit();
        }
    }
}
