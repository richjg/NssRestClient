namespace NssRestClient
{
    public class RestClientFactory
    {
        public static IRestClient Create() => new RestClient(HttpClientFactory.Instance, InMemoryClientCredentialStore.Instance);
        public static IRestClient Create(IHttpClientFactory httpClientFactory, IClientCredentialStore clientCredentialStore) => new RestClient(httpClientFactory, clientCredentialStore);
    }
}
