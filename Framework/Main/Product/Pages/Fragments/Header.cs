using AutomationFramework.Main.Framework.Browser;
using AutomationFramework.Main.Framework.UI.Components;
using OpenQA.Selenium;

namespace AutomationFramework.Main.Product.Pages.Fragments
{
    class Header
    {
        private readonly By searchField = By.Id("j-search");
        private readonly By cartButton = By.XPath("//span[@class='headerCartLabel']/ancestor::a");
        private readonly By searchButton = By.XPath("//button[@title='Искать']");

        public Header EnterSearchField(string text, bool isSubmit = false)
        {
            TextField textField = new TextField(searchField);
            textField.SendKeys(text);
            if (isSubmit) textField.Submit();
            return this;
        }

        public ChartPage ClickToChartButton()
        {
            BrowserManager.GetInstance().MoveToElement(cartButton);
            Button button = new Button(cartButton);
            BrowserManager.GetInstance().Refresh();
            button.Click();
            return new ChartPage();
        }

        public Header ClickSearchButton()
        {
            Button button = new Button(searchButton);
            button.Click();
            return this;
        }
    }
}
