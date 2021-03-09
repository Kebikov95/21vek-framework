using AutomationFramework.Main.Framework.Browser;
using OpenQA.Selenium;

namespace AutomationFramework.Main.Framework.UI.Components
{
    class Label : CommonPageElement
    {
        public Label(By by) : base(by) { }

        public string GetText()
        {
            WaitForElementIsVisible(by);
            return BrowserManager.GetInstance().GetText(by);
        }
    }
}
