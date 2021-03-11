using AutomationFramework.Main.Framework.Browser;
using AutomationFramework.Main.Framework.UI.Components;
using AutomationFramework.Main.Framework.Utils;
using OpenQA.Selenium;

namespace AutomationFramework.Main.Product.Pages
{
    class NotebooksPage : Page
    {
        private readonly string manufacturersCheckboxLocator = "//dt[text()='Производители']/../..//child::label/a[text()='{0}']";
        private readonly string notebookModelCheckboxLocator = "//dt/span[text()='Линейка']/../..//dd/label[@title='{0}']";
        private readonly string notebookTypeCheckboxLocator = "//dt/span[text()='Тип']/../..//label[@title='{0}']";
        private readonly string addToCartLinkLocator = "//span[@class='result__name' and text()='{0}']/../../../..//div[contains(@class, 'result__tools')]//button[text()='В корзину']";
        private readonly string discountPriceLabelLocator = "//span[@class='result__name' and text()='{0}']/../../../..//div[contains(@class, 'result__tools')]//span[@data-special_offer='discount']";

        private By priceFromInput = By.XPath("//input[@name='filter[price][from]']");
        private By priceToInput = By.XPath("//input[@name='filter[price][to]']");
        private By inStockCheckbox = By.XPath("//label[contains(text(), 'В наличии')]");
        private By rulerLink = By.XPath("//dt/span[text()='Линейка']");
        private By showAllLinks = By.XPath("//dt/span[text()='Линейка']/../following-sibling::dd/span");
        private By typeLink = By.XPath("//dt/span[text()='Тип']");
        private By showProductsButton = By.XPath("//button[@id='j-filter__btn']");

        public NotebooksPage EnterPriceFromInput(int price)
        {
            TextField textField = new TextField(priceFromInput);
            textField.SendKeys(price.ToString());
            return this;
        }

        public NotebooksPage EnterPriceToInput(int price)
        {
            TextField textField = new TextField(priceToInput);
            textField.SendKeys(price.ToString());
            return this;
        }

        public NotebooksPage ClickToInStockCheckbox()
        {
            Checkbox checkbox = new Checkbox(inStockCheckbox);
            checkbox.SetSelected(true);
            return this;
        }

        public NotebooksPage ClickToManufacturerCheckbox(string manufacture)
        {
            By manufacturersCheckboxBy = By.XPath(string.Format(manufacturersCheckboxLocator, manufacture));
            Checkbox checkbox = new Checkbox(manufacturersCheckboxBy);
            checkbox.SetSelected(true);
            return this;
        }

        public NotebooksPage ClickToManufacturerCheckbox(params string[] manufactures)
        {
            foreach (string manufacture in manufactures)
                ClickToManufacturerCheckbox(manufacture);
            return this;
        }

        public NotebooksPage ClickToRulerLink()
        {
            Link link = new Link(rulerLink);
            link.Click();
            return this;
        }

        public NotebooksPage ClickToNotebookModelCheckbox(string model)
        {
            By notebookModelCheckboxBy = By.XPath(string.Format(notebookModelCheckboxLocator, model));
            Checkbox checkbox = new Checkbox(notebookModelCheckboxBy);
            checkbox.SetSelected(true);
            return this;
        }

        public NotebooksPage ClickToNotebookModelCheckbox(params string[] models)
        {
            foreach (string model in models)
                ClickToNotebookModelCheckbox(model.Trim());
            return this;
        }

        public NotebooksPage ClickToShowAllLinks()
        {
            int firstScrollPoint = 0;
            int secondScrollPoint = 500;
            BrowserManager.GetInstance().ScrollBy(firstScrollPoint, secondScrollPoint);
            Link link = new Link(showAllLinks);
            link.Click();
            return this;
        }

        public NotebooksPage ClickToTypeLink()
        {
            Link link = new Link(typeLink);
            link.Click();
            return this;
        }

        public NotebooksPage ClickToNotebookTypeCheckbox(string type)
        {
            By notebookTypeCheckboxBy = By.XPath(string.Format(notebookTypeCheckboxLocator, type));
            Checkbox checkbox = new Checkbox(notebookTypeCheckboxBy);
            checkbox.SetSelected(true);
            return this;
        }

        public NotebooksPage ClickToNotebookTypeCheckbox(params string[] types)
        {
            foreach (string type in types)
                ClickToNotebookTypeCheckbox(type);
            return this;
        }

        public NotebooksPage ClickToShowProductsButton()
        {
            Button button = new Button(showProductsButton);
            button.Click();
            return this;
        }

        public NotebooksPage CkickToAddToCartButton(string name)
        {
            By notebookAddToCartLinkBy = By.XPath(string.Format(addToCartLinkLocator, name));
            Link link = new Link(notebookAddToCartLinkBy);
            BrowserManager.GetInstance().MoveToElement(notebookAddToCartLinkBy);
            link.Click();
            return this;
        }

        public string GetTextFromDiscountPriceLabelLocator(string name)
        {
            By notebookDiscountPriceLabelBy = By.XPath(string.Format(discountPriceLabelLocator, name));
            Label label= new Label(notebookDiscountPriceLabelBy);
            string price = label.GetText();
            return StringUtils.GetStringWithoutLetters(price);
        }
    }
}
