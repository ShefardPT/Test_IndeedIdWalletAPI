using System;
using System.Collections.Generic;
using System.Text;

namespace Test_IndeedIdWallet.Core.Services.Interfaces
{
    public interface ICurrencyApiClient
    {
        IEnumerable<string> GetCurrencies();
        double GetConversionRate(string baseCurrency, string targetCurrency);
    }
}
