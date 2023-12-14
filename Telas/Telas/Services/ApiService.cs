using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Telas.Services
{
    public static class ApiService<T> where T : class //generalizando a classe
    {
        private static HttpClient client;

        public static HttpClient Client
        {
            get
            {
                if (client == null)
                {
                    client = new HttpClient();
                    client.BaseAddress = new Uri("https://127.0.0.1:7222/api/");

                }
                return client;
            }
        }
        public async static Task<List<T>> GetList(string url)
        {
            var response = await Client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<List<T>>(content);
            return json;    
        }
    }
}
