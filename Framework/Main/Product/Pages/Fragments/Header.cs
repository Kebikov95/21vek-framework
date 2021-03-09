using AutomationFramework.Main.Framework.Browser;
using AutomationFramework.Main.Framework.UI.Components;
using OpenQA.Selenium;

namespace AutomationFramework.Main.Product.Pages.Fragments
{
    class Header
    {
        private By searchField = By.Id("j-search");
        private By cartButton = By.XPath("//span[@class='headerCartLabel']/ancestor::a");

        public void EnterSearchField(string text, bool isSubmit = false)
        {
            TextField textField = new TextField(searchField);
            textField.SendKeys(text);
            if (isSubmit) textField.Submit();
        }

        public ChartPage ClickToChartButton()
        {
            BrowserManager.GetInstance().Refresh();
            Button button = new Button(cartButton);
            button.Click();
            return new ChartPage();
        }
    }
}
