using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SkateStore.ApiGateways.Services
{
    public interface IHttpClientProvider
    {
        Task<KeyValuePair<HttpStatusCode, string>> DeleteHttpRequest(string baseUri, string uri);
        void Dispose();
        TType Get<TType>(string baseUri, string uri);
        Task<TType> GetAsync<TType>(string baseUri, string uri);
        Task<TType> GetHttpResponse<TType>(string baseUri, string uri);
        Task<HttpResponseMessage> PostHttpRequest<TType>(string baseUri, string uri, TType data, int timeout = 300);
        Task<KeyValuePair<HttpStatusCode, string>> PutHttpRequest<TType>(string baseUri, string uri, TType data);
    }
}
