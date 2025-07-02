using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json.Linq;

//so first we need to request an access token

namespace SpotifyBDD.services
{
    public class AccessToken
    {
        //ideally we have to use Env files to read but some issue is there..will resolve later

        private readonly string clientId="777084d57abe4535bc67af323fd82452";
        private readonly string clientSecret= "0f8caf444a37411e9528e69e8b0f0916";
        private readonly string url = "https://accounts.spotify.com/api/token";

        //first we need to send the Content-Type:application/x-www-form-urlencoded"
        //and the grant_type=client_credentials&client_id=your-client-id&client_secret=your-client-secret"

        public async Task<string> getToken()
        {
            string credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

                using HttpClient client = new HttpClient();
            
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
                //the above line will automatically add the Headers for Authorization


                FormUrlEncodedContent requestBody = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("grant_type","client_credentials")
                });

                //FormURLEncodedContent will make the ContentType Automatically in  application/x-www-form-urlencoded 

                HttpResponseMessage res = await client.PostAsync(url, requestBody);
                string responseContent = await res.Content.ReadAsStringAsync();

                var jsonObj = JObject.Parse(responseContent);
                return jsonObj["access_token"]?.ToString();
        }

        public static async Task Main()
        {
            AccessToken at = new AccessToken();
            string x=await at.getToken();
            Console.WriteLine(x);
        }


    }

    
}
