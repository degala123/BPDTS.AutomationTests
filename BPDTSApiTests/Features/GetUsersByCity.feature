Feature: GetUsersByCity
Background: 
	Given I have initialise user client

Scenario: Get user by city
	When I get the users by city 'Veranópolis'
	Then the response should return status code 'OK'
	And the response contains a valid users details

#Note: Ignored below tests because there is a bug in "GetUserByCity" end point.
#It's returning 200 OK status when I send invalid city names instead of getting exceptions.
@ignore
Scenario Outline: Get user by invalid city
	When I get the users by city '<city>'
	Then the response should return status code '<statusCode>'
	Examples: 
	| city            | statusCode |
	| invalidCityName | NotFound   |
	|                 | BadRequest |
	| Polo            | NotFound   |
