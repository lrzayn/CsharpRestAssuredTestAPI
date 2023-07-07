Feature: LabCorpTestAPI

@testAPI
Scenario: 01 POST JSON positive test
	Given API url is LabCorpPOST
	And JSON data for positive test
	When post sample json
	Then assert status code

Scenario: 02 GET data positive test
	Then send get request to validate username

Scenario: 03 POST JSON positive test, different language (Spain)

Scenario: 04 POST JSON positive test, different language (Chinese)

Scenario: 05 POST JSON negative test (wrong uri)

Scenario: 06 POST JSON negative test (wrong Json, some fields null)

Scenario: 07 GET data negative test (wrong username)

Scenario: 08 GET data negative test (username null)
