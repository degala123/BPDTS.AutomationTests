Feature: GetUserById
Background: 
	Given I have initialise user client

Scenario: Get user by id
	When I get the user by id '123'
	Then the response should return status code 'OK'
	And the response contains a valid user details

Scenario Outline: Get user by invalid id
	When I get the user by id '<id>'
	Then the response should return status code 'NotFound'
	And the response returns an error message <error>
	Examples: 
	| id   | error                  |
	| 0    | Id 0 doesn't exist.    |
	| -1   | Id -1 doesn't exist.   |
	| 1001 | Id 1001 doesn't exist. |
	| abcd | Id abcd doesn't exist. |
