using AutomationFramework.Main.Framework.Browser;
using AutomationFramework.Main.Framework.Utils;
using AutomationFramework.Main.Product.Pages;
using Framework.Main.Product.Pages.Fragments;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AutomationFramework.Test.Specflow.Steps
{
    [Binding]
    public sealed class NotebookSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private Page homePage;
        private NotebooksPage notebooksPage;
        private ChartPage chartPage;
        private LearnAboutAdmissionWindow learnAboutAdmissionPage;
        private string priceInNotebookPage;
        private string priceInChartPage;
        private string notificationText;
        private bool isDisplayRequiredFields;

        public NotebookSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I open the main page of the website")]
        public void GivenIOpenTheMainPageOfTheWebsite()
        {
            BrowserManager.GetInstance();
            homePage = new Page();
            homePage.Open();
        }

        [Given(@"I expand the menu item '(.*)'")]
        public void GivenIExpandTheMenuItem(string item)
        {
            homePage.GetNavigationContainer().ClickToMenuItem(item);
        }

        [Given(@"I go to Computer hardware link '(.*)'")]
        public void GivenIGoToComputerHardwareLink(string hardware)
        {
            notebooksPage = homePage.GetNavigationContainer().ClickToLinkItem(hardware);
        }

        [Given(@"I set the price range from '(.*)' - '(.*)' BYN")]
        public void GivenISetThePriceRangeFrom_BYN(int minPrice, int maxPrice)
        {
            notebooksPage.EnterPriceFromInput(minPrice);
            notebooksPage.EnterPriceToInput(maxPrice);
        }

        [Given(@"I set the checkbox in stock")]
        public void GivenISetTheCheckboxInStock()
        {
            notebooksPage.ClickToInStockCheckbox();
        }

        [Given(@"I set the checkbox manufacture - '(.*)'")]
        public void GivenISetTheCheckboxManufacture_(string manufactureNames)
        {
            string[] manufactureArray = StringUtils.SplitStringToArray(manufactureNames);
            notebooksPage.ClickToManufacturerCheckbox(manufactureArray);
        }

        [Given(@"I expand the ruler list, select the '(.*)' checkboxes")]
        public void GivenIExpandTheRulerListSelectTheCheckboxes(string modelNames)
        {
            notebooksPage.ClickToRulerLink();
            notebooksPage.ClickToShowAllLinks();
            string[] modelArray = StringUtils.SplitStringToArray(modelNames);
            notebooksPage.ClickToNotebookModelCheckbox(modelArray);
        }

        [Given(@"I expand the type list, select the '(.*)' checkbox")]
        public void GivenIExpandTheTypeListSelectTheCheckbox(string typeNames)
        {
            notebooksPage.ClickToTypeLink();
            string[] typeArray = StringUtils.SplitStringToArray(typeNames);
            notebooksPage.ClickToNotebookTypeCheckbox(typeArray);
        }

        [Given(@"I click the button show products")]
        public void GivenIClickTheButtonShowProducts()
        {
            notebooksPage.ClickToShowProductsButton();
        }

        [Given(@"I click the button to chart on the Laptop '(.*)'")]
        public void GivenIClickTheButtonToChartOnTheLaptop(string name)
        {
            notebooksPage.CkickToAddToCartButton(name);
        }

        [When(@"I check the value of the goods Laptop '(.*)'")]
        public void WhenICheckTheValueOfTheGoodsLaptop(string name)
        {
            priceInNotebookPage = notebooksPage.GetTextFromDiscountPriceLabelLocator(name);
            chartPage = notebooksPage.GetHeader().ClickToChartButton();
            priceInChartPage = chartPage.GetTextFromDiscountPriceLabel(name);
        }

        [Then(@"I should see the same prices")]
        public void ThenIShouldSeeTheSamePrices()
        {
            Assert.AreEqual(priceInChartPage, priceInNotebookPage, "Prices aren't equal.");
        }

        [Given(@"I click the button checkout order")]
        public void GivenIClickTheButton()
        {
            chartPage.ClickToCheckoutOrderButton();
        }

        [When(@"I check for messages about empty required fields")]
        public void WhenICheckForMessagesAboutEmptyRequiredFields()
        {
            chartPage.ClickToConfirmOrderButton();
            isDisplayRequiredFields = chartPage.IsDisplayRequiredFieldsMessage();
        }

        [Then(@"I should see messages about empty required fields")]
        public void ThenIShouldSeeMessagesAboutEmptyRequiredFields()
        {
            Assert.IsTrue(isDisplayRequiredFields, "The required massages haven't existed on page.");
        }

        [Given(@"I enter the word '(.*)' in the Search field")]
        public void GivenIEnterTheWordInTheSearchField(string productName)
        {
            homePage.GetHeader().EnterSearchField(productName);
        }

        [Given(@"I click the search button Submit")]
        public void GivenIClickTheSearchButtonSubmit()
        {
            homePage.ClickSearchButton();
        }

        [Given(@"I click under the product '(.*)' by the link inquire about receipt")]
        public void GivenIClickUnderTheProductByTheLinkInquireAboutReceipt(string productName)
        {
            learnAboutAdmissionPage = homePage.GetLearnAboutAdmissionWindow()
                .ClickToLearnAboutAdmissionButton(productName);
        }

        [Given(@"I click the button Submit")]
        public void GivenIClickTheButtonSubmit()
        {
            learnAboutAdmissionPage.ClickToSubmitButton();
        }

        [When(@"I check for messages about empty required fields in modal window")]
        public void WhenICheckForMessagesAboutEmptyRequiredFieldsInModalWindow()
        {
            isDisplayRequiredFields = learnAboutAdmissionPage.ClickToSubmitButton()
                .IsRequiredFieldsPresent();
        }

        [Given(@"I enter name '(.*)' and email '(.*)'")]
        public void GivenIEnterNameAndEmail(string name, string email)
        {
            learnAboutAdmissionPage.EnterNameField(name)
                .EnterEmailField(email);
        }

        [When(@"I check for the presence of the text in the modal window")]
        public void WhenICheckForThePresenceOfTheTextInTheModalWindow()
        {
            notificationText = learnAboutAdmissionPage.GetTextIntoNotificationLabel();
        }

        [Then(@"I should see the text '(.*)'")]
        public void ThenIShouldSeeTheText(string message)
        {
            Assert.AreEqual(notificationText, message, "The messages aren't equals.");
        }

        [Given(@"I click the close button")]
        public void GivenIClickTheCloseButton()
        {
            homePage = learnAboutAdmissionPage.ClickToCloseButton();
        }

        [When(@"I check under the item '(.*)'")]
        public void WhenICheckUnderTheItem(string productName)
        {
            isDisplayRequiredFields = homePage.IsProductWithWaitListLabel(productName);
        }

        [Then(@"I should see the text on the waiting list")]
        public void ThenIShouldSeeTheTextOnTheWaitingList()
        {
            Assert.IsTrue(isDisplayRequiredFields, "The product hasn't had wait label.");
        }
    }
}
