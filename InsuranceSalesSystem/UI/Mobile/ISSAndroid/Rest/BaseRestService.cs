using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace ISSAndroid.Rest
{
    public class BaseRestService
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
                    Debug.WriteLine(@"ERROR {0}", ex.Message);
                    throw;
                }

                return result;
            }
        }
    }
}