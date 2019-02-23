using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ISSMobile.Services
{
    public interface IRestService
    {
        Task<T> Get<T>(string url);
        Task Post<T>(string url, object data);
    }

    public class RestService : IRestService
    {
        public string BaseUrl = "http://10.101.32.18:53182/api/";

        public async Task<T> Get<T>(string path)
        {
            using (HttpClient client = new HttpClient())
            {
                T result = default(T);

                var url = $"{BaseUrl}{path}";
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

        public async Task Post<T>(string path, object data)
        {
            using (HttpClient client = new HttpClient())
            {
                T result = default(T);

                var url = $"{BaseUrl}{path}";
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
            }
        }

    }
}
