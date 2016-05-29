Feature: Getting some classifications
	In order to classify the context of text
	As a linguistic analyst
	I want to be able classify sentances

@Predicting a classification
Scenario Outline: Predict the classification of a sentence
	Given The user is on the index page
	And they enter the sentence <sentence>
	When the button labelled "classify" is clicked
	Then some text should be returned

	Examples:
	| sentence                    |
	| how hot will it be today? |
	| will it rain?             |

