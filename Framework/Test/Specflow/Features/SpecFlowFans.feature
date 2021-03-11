Feature: SpecFlowFansTest
	Simple tests to check the functionality of finding Fans on the site
	As a 21 vek site User
	In order to create BDD tests
	I want to check the search for a laptop with the specified parameters
	
Background: go to the website 21vek.by
	Given I open the main page of the website

 @smoke @notebook @positive @all
Scenario: Check the presence of the text in the waiting list under the product
	Given I enter the word 'Фен Philips HP' in the Search field
	Given I click the search button Submit
	Given I click under the product 'Фен Philips HP8233/00' by the link inquire about receipt
	Given I click the button Submit
	When I check for messages about empty required fields in modal window
	Then I should see messages about empty required fields
	Given I enter name 'user' and email 'email21vek@mail.com'
	Given I click the button Submit
	When I check for the presence of the text in the modal window
	Then I should see the text 'Если товар появится на складе, вам придет сообщение на почту.'
	Given I click the close button
	When I check under the item 'Фен Philips HP8233/00'
	Then I should see the text on the waiting list
