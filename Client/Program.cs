using System;
using System.Net.Http;
using Thinktecture.IdentityModel.Client;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //var response = GetToken();
            //Console.WriteLine(response.AccessToken);
            //CallApi(response);

            var response2 = GetUserToken();
            Console.WriteLine("token: " + response2.AccessToken);
            CallApi(response2);
        }

        //service to service authentication
        static TokenResponse GetToken()
        {
            var client = new OAuth2Client(
                new Uri("https://localhost:44333/connect/token"),
                "silicon",
                "F621F470-9731-4A25-80EF-67A6F7C5F4B8");

            return client.RequestClientCredentialsAsync("api1").Result;
        }

        //human to service authentication
        static TokenResponse GetUserToken()
        {
            var client = new OAuth2Client(
                new Uri("https://localhost:44333/connect/token"),
                "carbon",
                "21B5F798-BE55-42BC-8AA8-0025B903DC3B");

            return client.RequestResourceOwnerPasswordAsync("bob", "secret", "api1").Result;
        }

        static void CallApi(TokenResponse response)
        {
            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);
            Console.WriteLine("Calling api...");
            var result = client.GetStringAsync("http://localhost:47922/test").Result;
            Console.WriteLine("API called...");
            Console.WriteLine(result);

            //WebClient client = new WebClient();
            //client.Headers["Authorization"] = "Bearer " + response.AccessToken;
            //var result = client.DownloadString("http://localhost:47922/test");
            //Console.WriteLine("Result: " + result);
        }
    }
}
