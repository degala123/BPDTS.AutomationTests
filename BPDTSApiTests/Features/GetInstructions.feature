Feature: GetInstructions

Scenario: Get instructions
	Given I have initialise user client
	When I get instructions
	Then the response should return status code 'OK'
	And the response contains a valid instructions details