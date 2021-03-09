using AutomationFramework.Main.Framework.Browser;
using AutomationFramework.Main.Framework.UI.Components;
using AutomationFramework.Main.Framework.Utils;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AutomationFramework.Main.Product.Pages
{
    class ChartPage : Page
    {
        private readonly string discountPriceLabelLocator = "//a[text()='{0}']/../..//span[@class='promo__oldprice']/following-sibling::span/span";
        private By checkoutOrderButton = By.XPath("//button[@id='j-basket__ok']");
        private By confirmOrderButton = By.XPath("//button[@id='j-basket__confirm']");
        private By requiredFieldsMessage = By.XPath("//span[text()='Это поле обязательно для заполнения']");

        public string GetTextFromDiscountPriceLabel(string name)
        {
            By discountPriceLabelLocatorBy = By.XPath(string.Format(discountPriceLabelLocator, name));
            Label label = new Label(discountPriceLabelLocatorBy);
            string price = label.GetText();
            return StringUtils.GetStringWithoutLetters(price);
        }

        public ChartPage ClickToCheckoutOrderButton()
        {
            Button button = new Button(checkoutOrderButton);
            button.Click();
            return this;
        }

        public ChartPage ClickToConfirmOrderButton()
        {
            Button button = new Button(confirmOrderButton);
            button.Click();
            return this;
        }

        public bool IsDisplayRequiredFieldsMessage()
        {
            IWebDriver driver = BrowserManager.GetInstance().WrappedDriver;
            IList<IWebElement> elements = driver.FindElements(requiredFieldsMessage);
            return elements.Count > 0;
        }
    }
}
