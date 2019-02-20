using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ISSMobile.Services
{
    public class RestService
    {
        public static string BaseUrl = "http://10.101.32.18:53182/api/";

        public static async Task<T> Get<T>(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                T result = default(T);

                var uri = new Uri(url);

                try
                {
                    var response = await client.GetAsync(uri);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<T>(content);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }

                return result;
            }
        }

        public static async Task<T> Post<T>(string url, object data)
        {
            using (HttpClient client = new HttpClient())
            {
                T result = default(T);

                var uri = new Uri(url);
                var httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                try
                {
                    var response = await client.PostAsync(uri, httpContent);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<T>(content);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }

                return result;
            }
        }
    }
}
