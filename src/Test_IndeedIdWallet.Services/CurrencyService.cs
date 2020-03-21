using System;
using System.Linq;
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

        public bool IsExists(string currencyCode)
        {
            var currencies = _currencyApi.GetCurrencies();

            return currencies.Any(c => string.Equals(c, currencyCode, StringComparison.InvariantCultureIgnoreCase));
        }

        public double GetConversionRate(string baseCurrency, string targetCurrency)
        {
            return _currencyApi.GetConversionRate(baseCurrency, targetCurrency);
        }
    }
}
