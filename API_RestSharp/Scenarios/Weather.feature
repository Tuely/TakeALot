Feature: Weather
	
@API
Scenario: Verify Weather details
Given I enter the city as 'London'
Then I verify the response as '200'
	#Given I enter the resourse as '/api/users' with get method
	#When I create a new user with 'Name1' and 'Job1'
	#Then I verify the response with data 'Name1'