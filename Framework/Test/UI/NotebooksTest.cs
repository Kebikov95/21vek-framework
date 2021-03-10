using AutomationFramework.Main.Framework.Browser;
using AutomationFramework.Main.Product.Pages;
using Framework.Main.Product.Pages.Fragments;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;

namespace AutomationFramework.Test.UI
{
    class NotebooksTest
    {
        private Page homePage;

        [SetUp]
        public void Inizialize()
        {
            BrowserManager.GetInstance();
            homePage = new Page();
            BrowserManager.GetInstance().NavigateToUrl(homePage.Url);
        }

        [Test]
        public void CheckMessagesWithEmptyRequiredFields()
        {
            string notebookName = "Ноутбук Lenovo ThinkPad X1 Carbon Gen 8 (20U90006RT)";
            homePage.GetNavigationContainer().ClickToMenuItem("Компьютеры");
            NotebooksPage notebooksPage = homePage.GetNavigationContainer().ClickToLinkItem("Ноутбуки");
            notebooksPage.EnterPriceFromInput(1200)
                .EnterPriceToInput(6840)
                .ClickToInStockCheckbox()
                .ClickToManufacturerCheckbox("Lenovo")
                .ClickToRulerLink()
                .ClickToShowAllLinks()
                .ClickToNotebookModelCheckbox("IdeaPad L (Lenovo)", "ThinkPad E (Lenovo)", "ThinkPad X (Lenovo)")
                .ClickToTypeLink()
                .ClickToNotebookTypeCheckbox("ультрабук")
                .ClickToShowProductsButton()
                .CkickToAddToCartButton(notebookName);

            string priceInNotebookPage = notebooksPage.GetTextFromDiscountPriceLabelLocator(notebookName);
            ChartPage chartPage = notebooksPage.GetHeader().ClickToChartButton();
            string priceInChartPage = chartPage.GetTextFromDiscountPriceLabel(notebookName);
            Assert.AreEqual(priceInChartPage, priceInNotebookPage, "Prices aren't equal.");

            bool isDisplayRequiredFields = chartPage.ClickToCheckoutOrderButton()
                .ClickToConfirmOrderButton()
                .IsDisplayRequiredFieldsMessage();
            Assert.IsTrue(isDisplayRequiredFields, "The required massages haven't existed on page.");
        }

        [Test]
        public void ChecTextUnderTheProductInWaitingList()
        {
            string productName = "Фен Philips HP8233/00";
            homePage.GetHeader().EnterSearchField("Фен Philips HP");
            homePage.ClickSearchButton();
            LearnAboutAdmissionWindow learnAboutAdmissionPage = homePage.GetLearnAboutAdmissionWindow()
                .ClickToLearnAboutAdmissionButton(productName);

            bool isMessagesPresent = learnAboutAdmissionPage.ClickToSubmitButton()
                .IsRequiredFieldsPresent();
            Assert.IsTrue(isMessagesPresent, "The required massages haven't existed on page.");

            string notificationText = learnAboutAdmissionPage.EnterNameField("user")
                .EnterEmailField("email21vek@mail.com")
                .ClickToSubmitButton()
                .GetTextIntoNotificationLabel();
            Assert.AreEqual(notificationText, "Если товар появится на складе, вам придет сообщение на почту.", "The natification hasn't existed on page.");

            homePage = learnAboutAdmissionPage.ClickToCloseButton();
            bool isProductWithWaitLabel = homePage.IsProductWithWaitListLabel(productName);
            Assert.IsTrue(isProductWithWaitLabel, "The product hasn't had wait label.");
        }

        [OneTimeTearDown]
        public void TakeScreenShot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                ITakesScreenshot ssdriver = BrowserManager.GetInstance().WrappedDriver as ITakesScreenshot;
                Screenshot screenshot = ssdriver.GetScreenshot();
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd-hhmm");
                screenshot.SaveAsFile(@"..\..\..\..\Framework\Resources\Screenshots\" + timestamp +
                ".png", ScreenshotImageFormat.Png);
            }
        }

        [TearDown]
        public void Close()
        {
            IWebDriver driver = BrowserManager.GetInstance().WrappedDriver;
            driver.Manage().Cookies.DeleteAllCookies();
        }
    }
}
