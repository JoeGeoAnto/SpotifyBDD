Feature: Check if the correct artist is being searched 

@mytag
Scenario: To check if the artist that is being searched is expected from the API call
	Given a valid Access token 
	And the API endpoint for the artist is "TheWeeknd"
	When the API is called 
	Then the result should be "TheWeeknd"