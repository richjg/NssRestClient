using NssRestClient.Net;
using System;
using System.Net.Http;

namespace NssRestClient
{
    public class HttpClientFactory : IHttpClientFactory
    {
        private static HttpClient httpClient;

        public readonly static HttpClientFactory Instance = new HttpClientFactory();

        public HttpClient Create(string baseUrl)
        {
            if (string.IsNullOrWhiteSpace(baseUrl) || Uri.IsWellFormedUriString(baseUrl, UriKind.RelativeOrAbsolute) == false)
            {
                throw new ArgumentException("A valid url is required", nameof(baseUrl));
            }

            if (httpClient == null || httpClient.BaseAddress.OriginalString != baseUrl)
            {
                httpClient = new HttpClient(new RetryHandler(new HttpClientHandler()))
                {
                    BaseAddress = new Uri(baseUrl)
                };
            }

            return httpClient;
        }

        public HttpClient Create(NssConnectionState nssConnectionState) => Create(nssConnectionState.BaseUrl);

        public void Release()
        {
            try
            {
                httpClient?.Dispose();
            }
            catch { }

            httpClient = null;
        }
    }
}
