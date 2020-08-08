Feature: GetAllUsers

Scenario: Get all users
	Given I have initialise user client
	When I get all users
	Then the response should return status code 'OK'
	And the response contains a valid users details