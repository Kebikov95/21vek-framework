using AutomationFramework.Main.Framework.Browser;
using OpenQA.Selenium;
using System;

namespace AutomationFramework.Main.Framework.UI.Components
{
    class TextField : CommonPageElement
    {
        public TextField(By by) : base(by) { }

        public void Clear()
        {
            WaitForElementIsVisible(by);
            BrowserManager.GetInstance().Clear(by);
        }

        public void SendKeys(string text)
        {
            if (text == null) throw new ArgumentNullException("Invalid Text: Text cannot be null.");
            WaitForElementExists(by);
            BrowserManager.GetInstance().SendKeys(by, text);
        }

        public void Submit()
        {
            WaitForElementExists(by);
            BrowserManager.GetInstance().Submit(by);
        }

        public string GetText => GetAttribute(by, "value");
    }
}
