using System;
using System.Linq;
using System.Threading.Tasks;
using Test_IndeedIdWallet.Core.Services.Interfaces;

namespace Test_IndeedIdWallet.Services
{
    public class CurrencyService : ICurrencyService
    {
        private ICurrencyApiClient _currencyApi;

        public CurrencyService(ICurrencyApiClient currencyApi)
        {
            _currencyApi = currencyApi;
        }

        public async Task<bool> IsExists(string currencyCode)
        {
            var currencies = await _currencyApi.GetCurrencies();

            return currencies.Any(c => string.Equals(c, currencyCode, StringComparison.InvariantCultureIgnoreCase));
        }

        public async Task<double> GetConversionRate(string baseCurrency, string targetCurrency)
        {
            return await _currencyApi.GetConversionRate(baseCurrency, targetCurrency);
        }
    }
}
