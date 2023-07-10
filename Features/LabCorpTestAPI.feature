Feature: LabCorpTestAPI

@testAPI
Scenario: 01 POST JSON positive test
	Given API url is LabCorpPOST
	And JSON data for positive test
	When post sample json 200
	Then assert status code 200

Scenario: 02 GET data positive test
	Then send get request to validate username

Scenario: 03 POST JSON positiveSpain test, different language (Spain)
	Given API url is LabCorpPOST
	And JSON data for positiveSpain test
	When post sample json 200
	Then assert status code 200

Scenario: 04 POST JSON positiveChinese test, different language (Chinese)
	Given API url is LabCorpPOST
	And JSON data for positiveChinese test
	When post sample json 200
	Then assert status code 200

Scenario: 05 POST JSON negativeURI test (wrong uri)
	Given API url is LabCorpPOSTnegative
	And JSON data for positive test
	When post sample json 500
	Then assert status code 500

Scenario: 06 POST JSON negative test (wrong Json, some fields/username null)
	Given API url is LabCorpPOST
	And JSON data for negative test
	When post sample json 500
	Then assert status code 500