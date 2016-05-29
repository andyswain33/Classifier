Feature: serializeing the JSon data
	In order to work with the classification data
	As a software developer
	I want to be able to serialize the JSon data 

@processing the data
Scenario: Serializing an example string taken from the service.
	Given I have a example Json string
	When I process the data
	Then A sertialized result model will be created
	And the model will have some content

	Scenario: Serializing an real string taken from the service.
	Given I have a real Json string
	When I process the data
	Then A sertialized result model will be created
	And the model will have some content
