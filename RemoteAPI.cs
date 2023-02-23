using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Adachi_ChatGPT_testing
{
    class RemoteAPI
    {
        private readonly Uri _uri;
        private readonly string _username;
        private readonly string _password;

        public RemoteAPI(Uri uri, string username, string password)
        {
            _uri = uri;
            _username = username;
            _password = password;
        }
        
        public async Task<string> SendHelloWorld()
        {
            // Create a new HttpClient instance
            using (HttpClient client = new HttpClient())
            {
                // Set the remote endpoint URI
                client.BaseAddress = _uri;

                // Configure SSL/TLS connection
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                // Set basic authentication header
                string authHeader = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_username}:{_password}"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeader);

                // Create a new HTTP POST request with the "Hello World" payload
                var content = new StringContent("Hello World", Encoding.UTF8, "text/plain");
                var response = await client.PostAsync("", content);

                // Check if the response was successful
                response.EnsureSuccessStatusCode();

                // Read the response content as a string and return it
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
