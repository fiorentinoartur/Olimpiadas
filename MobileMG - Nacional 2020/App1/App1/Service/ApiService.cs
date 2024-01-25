using App1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App1.Service
{
    public static class ApiService<T> where T : class
    {

        private static HttpClient client;

        public static HttpClient Client
		{
            get
            {
                if (client == null)
                {
                    client = new HttpClient();
                    client.BaseAddress = new Uri("http://10.0.2.2:5500/api/");
                }
                return client;
            }

        }

      public static async Task<List<T>> GetList(string url)
        {
            var response = await Client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<List<T>>(content);
            return json;
        }
        public static async Task<T> Get(string url)
        {
            var response = await Client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<T>(content);
            return json;
        }

    }
}
