Feature: downloading some data
	In order to retrieve data
	As an analyst
	I want to be able to communicate with the ibm service.

@mytag
Scenario: Downloading some sample data
	Given I use the username "b4949ffd-0f75-433a-8cda-3e1aaa75b91d"
	And I use the password "rLVfGY4ttyeh"
	And I use the sentence "how hot will it be today?"
	When I call the service
	Then I should retrieve some data

Scenario Outline: Get classifications for sentences
	Given I use the username "b4949ffd-0f75-433a-8cda-3e1aaa75b91d"
	And I use the password "rLVfGY4ttyeh"
	And I use the sentence <sentence>
	When I request a classification
	Then the returned classification will be <classification>

	Examples: 
	| sentence                    | classification |
	| "how hot will it be today?" | "temperature"  |
	| "Will we get snow?"         | "conditions"   |