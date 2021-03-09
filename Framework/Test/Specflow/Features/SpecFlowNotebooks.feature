﻿Feature: SpecFlowNoteBooksTest
	Simple tests to check the functionality of finding laptops on the site
	As a 21 vek site User
	In order to create BDD tests
	I want to check the search for a laptop with the specified parameters
	
Background: go to the website 21vek.by
	Given I open the main page of the website

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

 @smoke @notebook @positive @all
Scenario: Check the presence of the text in the waiting list under the product
	Given I enter the word 'Фен Philips HP' in the Search field
	Given I click the search button Submit
	Given I click under the product 'Фен Philips HP8238/00' by the link inquire about receipt
	Given I click the button Submit
	When I check for messages about empty required fields in modal window
	Then I should see messages about empty required fields
	Given I enter name 'user' and email 'email21vek@mail.com'
	Given I click the button Submit
	When I check for the presence of the text in the modal window
	Then I should see the text 'Если товар появится на складе, вам придет сообщение на почту.'
	Given I click the close button
	When I check under the item 'Фен Philips HP8238/00'
	Then I should see the text on the waiting list
