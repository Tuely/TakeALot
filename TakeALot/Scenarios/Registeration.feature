Feature: Registeration
	
Background:
Given I navigate into Take a lot 

@Regression
Scenario: Register a new user
	
Given I click Register Link
When I enter registartion details as 'Test', 'Last', 'email' , '123456', '07465456767'
Then I verify the user is registered
