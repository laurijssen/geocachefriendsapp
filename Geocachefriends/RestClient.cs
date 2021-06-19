using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Geocachefriends
{
    public class RestService
    {
        HttpClient client;

        public string UserName { get; set; }
        public string  Password { get; set; }

        public RestService(string username, string password)
        {
            client = new HttpClient();

            UserName = username;
            Password = password;
        }

        public async Task<string> GetTokenAsync()
        {
            string url = "https://geocachefriends.herokuapp.com/api/v1/tokens/";

            Uri uri = new Uri(url);

            client.DefaultRequestHeaders.Authorization = new BasicAuthenticationHeaderValue(UserName, Password);

            HttpResponseMessage response = await client.PostAsync(uri, null);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                return content;
            }
            return string.Empty;
        }
    }
}
