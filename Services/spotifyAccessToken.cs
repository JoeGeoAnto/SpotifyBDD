using Newtonsoft.Json.Linq;
using DotNetEnv;
using System.Net.Http.Headers;
using System.Text;


namespace SpotifyBDD.Services
{
    class SpotifyAuth
    {
        private string clientId;
        private string clientSecret;
        private readonly string envPath = @"C:\Users\jantony\source\repos\SpotifyBDD\.env";
        private readonly string accessTokenPrefix = "ACCESS_TOKEN=";

        public async Task GetAccessTokenAsync()
        {
            Env.Load(envPath);

            clientId = Environment.GetEnvironmentVariable("CLIENT_ID")!;
            clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET")!;

            using HttpClient client = new HttpClient();

            string credentials = $"{clientId}:{clientSecret}";
            var encodedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encodedCredentials);

            var requestBody = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("grant_type", "client_credentials")
            });

            HttpResponseMessage response = await client.PostAsync("https://accounts.spotify.com/api/token", requestBody);
            var content = await response.Content.ReadAsStringAsync();

            var json = JObject.Parse(content);
            Console.WriteLine(json["access_token"]?.ToString());
            string result = json["access_token"]?.ToString() ?? "Empty";

            List<string> lines = File.Exists(envPath)
            ? File.ReadAllLines(envPath).ToList()
            : new List<string>();

            bool updated = false;

            // Search for the key and update its value if found
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].StartsWith(accessTokenPrefix))
                {
                    lines[i] = $"{accessTokenPrefix}{result}";
                    updated = true;
                    break;
                }
            }

            // If key was not found, add it
            if (!updated)
            {
                lines.Add($"{accessTokenPrefix}{result}");
            }

            // Write the updated lines back to the .env file
            File.WriteAllLines(envPath, lines);


        }

    }
}