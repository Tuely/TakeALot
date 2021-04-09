Feature: ShoppingCart

Background:
	Given I navigate into Take a lot

@Regression
Scenario: Verify the shopping cart
Given I search for 'Garmin Forerunner 45S Sports Watch Black'
When  I add item into shopping bag
Then I verify 'Garmin Forerunner 45S Sports Watch Black' item has been added to the cart
