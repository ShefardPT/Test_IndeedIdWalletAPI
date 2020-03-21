using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Test_IndeedIdWallet.Core.Services.Interfaces;

namespace Test_IndeedIdWallet.Services
{
    public class ExchangeRatesCurrencyApiClient : ICurrencyApiClient
    {
        private HttpClient _httpClient;
        private string Url { get; } = "https://api.exchangeratesapi.io/";

        public ExchangeRatesCurrencyApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<string>> GetCurrencies()
        {
            var latestRatesResponse = await _httpClient.GetAsync(Url + "latest");

            if (!latestRatesResponse.IsSuccessStatusCode)
            {
                throw new OperationCanceledException("Currency API is unavailable now.");
            }

            var latestRates = JsonConvert.DeserializeObject<ExchangeRatesCurrencyApiResponse>
                (await latestRatesResponse.Content.ReadAsStringAsync());

            var result = latestRates.Rates.Select(x => x.Key);
            result = result.Append(latestRates.Base);

            return result;
        }

        public async Task<double> GetConversionRate(string baseCurrency, string targetCurrency)
        {
            var requestParams = $"base={baseCurrency}&" +
                                $"symbols={targetCurrency}";

            var latestRatesResponse = await _httpClient.GetAsync(Url + "latest?" + requestParams);

            if (!latestRatesResponse.IsSuccessStatusCode)
            {
                if (latestRatesResponse.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new ArgumentException("One of give currency is not supported.");
                }
                else
                {
                    throw new OperationCanceledException("Currency API is unavailable now.");
                }
            }

            var latestRates = JsonConvert.DeserializeObject<ExchangeRatesCurrencyApiResponse>
                (await latestRatesResponse.Content.ReadAsStringAsync());

            return latestRates.Rates.FirstOrDefault().Value;
        }

        private class ExchangeRatesCurrencyApiResponse
        {
            public string Base { get; set; }
            public DateTime Date { get; set; }
            public Dictionary<string, double> Rates { get; set; }
        }
    }
}
