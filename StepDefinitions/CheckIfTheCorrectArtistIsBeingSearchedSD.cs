using System;
using Reqnroll;

namespace SpotifyBDD.StepDefinitions
{
    [Binding]
    public class CheckIfTheCorrectArtistIsBeingSearchedSD
    {
        [Given("a valid Access token")]
        public void GivenAValidAccessToken()
        {
            throw new PendingStepException();
        }

        [Given("the API endpoint for the artist is {string}")]
        public void GivenTheAPIEndpointForTheArtistIs(string theWeeknd)
        {
            throw new PendingStepException();
        }

        [When("the API is called")]
        public void WhenTheAPIIsCalled()
        {
            throw new PendingStepException();
        }

        [Then("the result should be {string}")]
        public void ThenTheResultShouldBe(string theWeeknd)
        {
            throw new PendingStepException();
        }
    }
}
