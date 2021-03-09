using AutomationFramework.Main.Framework.Browser;
using OpenQA.Selenium;

namespace AutomationFramework.Main.Framework.UI.Components
{
    class Link : CommonPageElement
    {
        public Link(By by) : base(by) { }

        public void Click()
        {
            WaitForElementToBeClickable(by);
            BrowserManager.GetInstance().Click(by);
        }

        public string GetText()
        {
            WaitForElementIsVisible(by);
            return BrowserManager.GetInstance().GetText(by);
        }
    }
}
