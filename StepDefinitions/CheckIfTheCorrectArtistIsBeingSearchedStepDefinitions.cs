using System;
using Reqnroll;

namespace SpotifyBDD.StepDefinitions
{
    [Binding]
    public class CheckIfTheCorrectArtistIsBeingSearchedStepDefinitions
    {
        [Given("the access token")]
        public void GivenTheAccessToken()
        {
            throw new PendingStepException();
        }

        [Given("the artist endpoint as an api endpoint")]
        public void GivenTheArtistEndpointAsAnApiEndpoint()
        {
            throw new PendingStepException();
        }

        [When("the artist to be searched is TheWeeknd")]
        public void WhenTheArtistToBeSearchedIsTheWeeknd()
        {
            throw new PendingStepException();
        }

        [Then("the artist that is fetched is {string}")]
        public void ThenTheArtistThatIsFetchedIs(string theWeeknd)
        {
            throw new PendingStepException();
        }
    }
}
