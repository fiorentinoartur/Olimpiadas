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
                    client.BaseAddress = new Uri("http://10.0.2.2:55542/api/");
                }
                return client;
            }

        }

        public static async Task<bool> Login(string userName, string password)
        {
            try
            {
                var loginModel = new { UserName = userName, Password = password };

                var jsonCredentials = JsonConvert.SerializeObject(loginModel);

                var content = new StringContent(jsonCredentials, Encoding.UTF8, "application/json");

                var response = await Client.PostAsync("login", content);

                if(response.IsSuccessStatusCode) 
                { 
                return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async static Task<List<T>> GetList(string url)
        {
            try
            {
                var response = await Client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<T>>(content);
                    return result;
                }
                else
                {
                    // Adicione o tratamento para obter mais informações sobre o erro
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error: {errorMessage}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return null;
            }
        }

    }
}
