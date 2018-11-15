using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PolicyService.Bo.Infrastructure.Communication.REST
{
    public class ApiClient
    {
        private readonly string BaseUrl;

        public ApiClient(string baseUrl)
        {
            if (baseUrl.EndsWith('/'))
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }

            BaseUrl = baseUrl;
        }

        public async Task<T> Post<T>(string controller, string action, object data)
        {
            var url = $"{BaseUrl}/{controller}";

            if (action != null)
            {
                url += $"/{action}";
            }

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var serializedData = SerializeData(data);
                var taskResponse = await client.PostAsync(url, new StringContent(serializedData, Encoding.UTF8, "application/json"));

                var stringResponse = await taskResponse.Content.ReadAsStringAsync();

                return DeserializeData<T>(stringResponse);                
            }
        }

        private string SerializeData(object data)
        {
            return JsonConvert.SerializeObject(data);
        }

        private T DeserializeData<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

    }
}
