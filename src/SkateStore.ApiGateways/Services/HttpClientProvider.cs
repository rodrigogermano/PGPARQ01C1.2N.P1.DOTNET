using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SkateStore.ApiGateways.Services
{
    public class HttpClientProvider : IDisposable, IHttpClientProvider
    {
        public TType Get<TType>(string baseUri, string uri)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                client.Timeout = TimeSpan.FromMinutes(10);
                                
                var response = client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    var obj = JsonConvert.DeserializeObject<TType>(result);

                    return obj;
                }
            }

            return default(TType);
        }

        public async Task<TType> GetAsync<TType>(string baseUri, string uri)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                client.Timeout = TimeSpan.FromMinutes(10);
                                
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TType>(result);
                }
            }

            return default(TType);
        }

        public async Task<TType> GetHttpResponse<TType>(string baseUri, string uri)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                client.Timeout = TimeSpan.FromMinutes(10);

                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TType>(result);
                }
            }

            return default(TType);
        }

        public async Task<HttpResponseMessage> PostHttpRequest<TType>(string baseUri, string uri, TType data, int timeout = 300)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                client.Timeout = TimeSpan.FromSeconds(timeout);
                
                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, content);

                return response;
            }            
        }

        public async Task<KeyValuePair<HttpStatusCode, string>> PutHttpRequest<TType>(string baseUri, string uri, TType data)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                client.Timeout = TimeSpan.FromMinutes(10);

                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var response = await client.PutAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    return new KeyValuePair<HttpStatusCode, string>(response.StatusCode, string.Empty);
                }

                var result = await response.Content.ReadAsStringAsync();
                return new KeyValuePair<HttpStatusCode, string>(response.StatusCode, result);
            }
        }

        public async Task<KeyValuePair<HttpStatusCode, string>> DeleteHttpRequest(string baseUri, string uri)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                client.Timeout = TimeSpan.FromMinutes(10);

                var response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    return new KeyValuePair<HttpStatusCode, string>(response.StatusCode, string.Empty);
                }

                var result = await response.Content.ReadAsStringAsync();
                return new KeyValuePair<HttpStatusCode, string>(response.StatusCode, result);
            }
        }

        public void Dispose()
        {

        }
    }
}
