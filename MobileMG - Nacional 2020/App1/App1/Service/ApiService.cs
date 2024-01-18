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

        public static async Task<T> Login(LoginUser usuario)
        {
           
                var jsonLoginModel = JsonConvert.SerializeObject(usuario);
            var response = await Client.PostAsync("login", new StringContent(jsonLoginModel, Encoding.UTF8, "application/json"));

            if(response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(jsonResponse);

                return result;
            }
       return null;
                //var loginModel = new {  usuarios.email, usuarios.senha };

                //var jsonCredentials = JsonConvert.SerializeObject(loginModel);

                //var content = new StringContent(jsonCredentials, Encoding.UTF8, "application/json");

                //var response = await Client.PostAsync("login", content);
                //var contentt = await response.Content.ReadAsStringAsync();  
                //var json = JsonConvert.DeserializeObject<T>(contentt);


                //if (response.IsSuccessStatusCode)
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
          
        }

        public async static Task<List<T>> GetList(string url)
        {
            var response = await Client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var result = new List<T>();
            var json = JsonConvert.DeserializeObject<List<T>>(content);
            return json;
        }

    }
}
