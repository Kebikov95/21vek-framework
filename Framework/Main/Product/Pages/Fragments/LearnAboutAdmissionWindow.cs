using AutomationFramework.Main.Framework.Browser;
using AutomationFramework.Main.Framework.UI.Components;
using AutomationFramework.Main.Product.Pages;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Framework.Main.Product.Pages.Fragments
{
    class LearnAboutAdmissionWindow
    {
        private readonly string learnAboutAdmissionButtonLocator = "//span[text()='{0}']/../../..//a[text()='Узнать о поступлении']";
        private readonly By nameField = By.XPath("//input[@name='data[name]']");
        private readonly By emailField = By.XPath("//input[@name='data[email]']");
        private readonly By sendButton = By.XPath("//span[text()='Отправить']/ancestor::button");
        private readonly By closeLink = By.XPath("(//span[text()='Закрыть']");
        private readonly By closeButton = By.XPath("//span[text()='Закрыть']/ancestor::button");
        private readonly By requiredFields = By.XPath("//span[text()='Это поле обязательно для заполнения']");
        private readonly By notificationLabel = By.XPath("//div[contains(@class, 'g-form__label')]");

        public LearnAboutAdmissionWindow ClickToLearnAboutAdmissionButton(string productName)
        {
            By learnAboutAdmissionButtonBy = By.XPath(string.Format(learnAboutAdmissionButtonLocator, productName));
            Button button = new Button(learnAboutAdmissionButtonBy);
            button.Click();
            return this;
        }

        public LearnAboutAdmissionWindow EnterNameField(string name)
        {
            TextField field = new TextField(nameField);
            field.SendKeys(name);
            return this;
        }

        public LearnAboutAdmissionWindow EnterEmailField(string email)
        {
            TextField field = new TextField(emailField);
            field.SendKeys(email);
            return this;
        }

        public LearnAboutAdmissionWindow ClickToSubmitButton()
        {
            Button button = new Button(sendButton);
            button.Click();
            return this;
        }

        public Page ClickToCloseLink()
        {
            Link link = new Link(closeLink);
            link.Click();
            return new Page();
        }

        public Page ClickToCloseButton()
        {
            Button button = new Button(closeButton);
            button.Click();
            return new Page();
        }

        public bool IsRequiredFieldsPresent()
        {
            IWebDriver driver = BrowserManager.GetInstance().WrappedDriver;
            IList<IWebElement> elements = driver.FindElements(requiredFields);
            return elements.Count > 0;
        }

        public string GetTextIntoNotificationLabel()
        {
            Label label = new Label(notificationLabel);
            string text = label.GetText().Trim();
            return text;
        }
    }
}
