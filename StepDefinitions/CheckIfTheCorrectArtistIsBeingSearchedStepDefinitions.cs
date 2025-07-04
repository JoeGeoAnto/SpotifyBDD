using DotNetEnv;
using NUnit.Framework;
using System.Net;
using System.Text.Json;
using System.Net.Http.Headers;

namespace SpotifyBDD.StepDefinitions
{
    [Binding]
    public class CheckIfTheCorrectArtistIsBeingSearchedStepDefinitions
    {
        private readonly string envPath = @"C:\Users\jantony\source\repos\SpotifyBDD\.env";
        private string apiPath;
        private HttpResponseMessage res;


        [Given("the artist endpoint as an api {string}")]
        public void GivenTheArtistEndpointAsAnApi(string endpoint)
        {
            apiPath = endpoint;
        }

        [Given("a valid access token")]
        public async Task GivenAValidAccessToken()
        {
            //check if the access token is there in env file
            Env.Load(envPath);
            string accessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN")!;

            if (accessToken == null)
            {
                Assert.Fail("The given access token does not exist");
            }

            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await client.GetAsync(apiPath);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error response body:");
                Console.WriteLine(responseBody);
                Assert.Fail("LOL1");
            }
        }

        [When("the artist to be searched is TheWeeknd")]
        public async Task WhenTheArtistToBeSearchedIsTheWeeknd()
        {
            using HttpClient client = new HttpClient();
            res = await client.GetAsync(apiPath);
        }

        [Then("the artist that is fetched is {string}")]
        public async Task ThenTheArtistThatIsFetchedIs(string theWeeknd)
        {
            string jsonString = await res.Content.ReadAsStringAsync();
            using JsonDocument doc = JsonDocument.Parse(jsonString);

            if(doc.RootElement.TryGetProperty("name", out JsonElement nameElement))
            {
                string name = nameElement.GetString();
                Assert.That(name == theWeeknd, "Something went wrong");
            }

        }
    }
}
