Feature: VerifyWeather

@APIRegression
Scenario: Verify the Weather in a city
	Given I have enter city as 'London'
	When I send request to API
	Then The Co-Ordinates returned will be long '-0.1257' lat '51.1376409'

	
Scenario: When sending in an invalid API key, check error returned
	Given I have enter city as 'London'
	When I send request to API with API Key '11111a11111'
	Then an error of 'REQUEST_DENIED' will be returned

	Scenario: When sending in an valid API key, check response status
	Given I have enter city as 'London'
	When I send request to API with API Key '735f339d0f209df2e477468a6f77f111'
	Then response will be '200'