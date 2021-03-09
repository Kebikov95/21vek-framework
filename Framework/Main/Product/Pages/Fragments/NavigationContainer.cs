using AutomationFramework.Main.Framework.UI.Components;
using OpenQA.Selenium;

namespace AutomationFramework.Main.Product.Pages.Fragments
{
    class NavigationContainer
    {
        private string menuItemLocator = "//div[@class='navigationNav']//span[text()='{0}']";
        private string linkItemLocator = "//dl[@class='subnavDefinitions']//a[text()='{0}']";

        public void ClickToMenuItem(string name)
        {
            string locator = string.Format(menuItemLocator, name);
            By menuItemBy = By.XPath(locator);
            Button button= new Button(menuItemBy);
            button.Click();
        }

        public NotebooksPage ClickToLinkItem(string name)
        {
            string locator = string.Format(linkItemLocator, name);
            By linkItemBy = By.XPath(locator);
            Link link = new Link(linkItemBy);
            link.Click();
            return new NotebooksPage();
        }
    }
}
