Feature: Create User
 
@prio1
Scenario Outline: Create user - successfully create user
	Given I populate create user request with (<Name>,<Email>,<Gender>,<Status>)
	When I execute create user request
	Then I validate user is successfully created 201
	Examples: 
	| Name | Email             | Gender | Status |
	| Test | Test999@gmail.com | Male   | Active |