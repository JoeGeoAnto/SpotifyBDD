Feature: Check if the correct artist is being searched 

@mytag
Scenario: To check if the artist that is being searched is expected from the API call
	Given the access token
	And the artist endpoint as an api endpoint
	When the artist to be searched is TheWeeknd
	Then the artist that is fetched is "TheWeeknd"