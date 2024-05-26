using Newtonsoft.Json;
using SimpleTrader.FinancialModelingPrepAPI.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI
{
    public class FinancialModelingPrepHttpClient
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;

        public FinancialModelingPrepHttpClient(HttpClient client, FinancialModelingPrepAPIKey apiKey)
        {
            _client = client;
            _apiKey = apiKey.Key;
        }

        public async Task<T> GetAsync<T>(string uri, string paramsQuery = "")
        {
            string key = "mStarkBxBNHlABxUtnPuC75uGrdv8omX";
            string key2 = "lEtVikA60rFypGgEompkYiH6xV3To7gW";
            HttpResponseMessage response = await _client.GetAsync($"https://financialmodelingprep.com/api/v3/{uri}?apikey={key2}{paramsQuery}");
            string jsonResponse = await response.Content.ReadAsStringAsync();
            var responseConverted = JsonConvert.DeserializeObject<T>(jsonResponse);
            return responseConverted;
        }
    }
}
