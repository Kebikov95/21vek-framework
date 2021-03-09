using AutomationFramework.Main.Framework.Browser;
using OpenQA.Selenium;

namespace AutomationFramework.Main.Framework.UI.Components
{
    class Button : CommonPageElement
    {
        public Button(By by) : base(by) { }

        public void Click()
        {
            WaitForElementToBeClickable(by);
            BrowserManager.GetInstance().Click(by);
        }

        public void GetText()
        {
            WaitForElementIsVisible(by);
            BrowserManager.GetInstance().GetText(by);
        }
    }
}
