Feature: Check if the correct artist is being searched 

@mytag
Scenario: To check if the artist that is being searched is expected from the API call
	Given the artist endpoint as an api "https://api.spotify.com/v1/artists/1Xyo4u8uXC1ZmMpatF05PJ"
	And a valid access token 
	When the artist to be searched is TheWeeknd
	Then the artist that is fetched is "The Weeknd"