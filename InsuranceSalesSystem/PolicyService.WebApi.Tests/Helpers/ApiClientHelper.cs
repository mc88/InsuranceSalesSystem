using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PolicyService.WebApi.Tests.Helpers
{
    public static class ApiClientHelper
    {
        public static async Task<T> Post<T>(string url, object data)
        {
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

        private static string SerializeData(object data)
        {
            return JsonConvert.SerializeObject(data);
        }

        private static T DeserializeData<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}
