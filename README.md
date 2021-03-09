## Automation Framework for site www.21vek.by
___
### Design Patterns
To write the pages of this framework, the following design patterns were used: Decorator, Singleton, Page Object, Page Elment.
___
### The tests were written using the [NUnit](https://nunit.org/) and [SpecFlowtesting](https://specflow.org/) framework.

#### NUnit
> NUnit is a unit-testing framework for all .Net languages. Initially ported from JUnit, the current production release, version 3, has been completely rewritten with many new features and support for a wide range of .NET platforms.

#### SpecFlow
> Write examples in your native language with the easy to understand Gherkin Syntax (Given-When-Then). 
___
### NUnit Example
```
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
```

### SpecFlow Example
```
@smoke @notebook @positive @all
Scenario: Check for messages about empty required fields
	Given I expand the menu item 'Компьютеры'
	Given I go to Computer hardware link 'Ноутбуки'
	Given I set the price range from '1200' - '6840' BYN
	Given I set the checkbox in stock
	Given I set the checkbox manufacture - 'Lenovo'
	Given I expand the ruler list, select the 'IdeaPad L (Lenovo), ThinkPad E (Lenovo), ThinkPad X (Lenovo)' checkboxes
	Given I expand the type list, select the 'ультрабук' checkbox
	Given I click the button show products
	Given I click the button to chart on the Laptop 'Ноутбук Lenovo ThinkPad X1 Carbon Gen 8 (20U90006RT)'
	When I check the value of the goods Laptop 'Ноутбук Lenovo ThinkPad X1 Carbon Gen 8 (20U90006RT)'
	Then I should see the same prices
	Given I click the button checkout order
	When I check for messages about empty required fields
	Then I should see messages about empty required fields
```
