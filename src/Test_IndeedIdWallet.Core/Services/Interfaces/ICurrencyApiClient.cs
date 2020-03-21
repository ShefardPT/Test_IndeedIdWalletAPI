using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Test_IndeedIdWallet.Core.Services.Interfaces
{
    public interface ICurrencyApiClient
    {
        Task<IEnumerable<string>> GetCurrencies();
        Task<double> GetConversionRate(string baseCurrency, string targetCurrency);
    }
}
