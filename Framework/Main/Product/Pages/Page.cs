using AutomationFramework.Main.Framework.Browser;
using AutomationFramework.Main.Framework.UI.Components;
using AutomationFramework.Main.Product.Pages.Fragments;
using Framework.Main.Product.Pages.Fragments;
using OpenQA.Selenium;

namespace AutomationFramework.Main.Product.Pages
{
    class Page
    {
        public readonly string Url = "https://www.21vek.by/";
        protected Header header = new Header();
        protected NavigationContainer navContainer = new NavigationContainer();
        protected LearnAboutAdmissionWindow learnAboutAdmissionWindow = new LearnAboutAdmissionWindow();
        private readonly string inWaitListLabelLocator = "//span[text()='{0}']/../../..//span[text()='В листе ожидания']";

        public Header GetHeader() => header;

        public NavigationContainer GetNavigationContainer() => navContainer;

        public LearnAboutAdmissionWindow GetLearnAboutAdmissionWindow() => learnAboutAdmissionWindow;

        public Page Open()
        {
            BrowserManager.GetInstance().NavigateToUrl(Url);
            return this;
        }

        public bool IsProductWithWaitListLabel(string productName)
        {
            By inWaitListLabelBy = By.XPath(string.Format(inWaitListLabelLocator, productName));
            Label label = new Label(inWaitListLabelBy);
            string text = label.GetText();
            return text.Contains("В листе ожидания");
        }
    }
}
