using System.Net.Http;

namespace NssRestClient
{
    public interface IHttpClientFactory
    {
        void Release();
        HttpClient Create(string baseUrl);
        HttpClient Create(NssConnectionState nssConnectionState);
    }
}
