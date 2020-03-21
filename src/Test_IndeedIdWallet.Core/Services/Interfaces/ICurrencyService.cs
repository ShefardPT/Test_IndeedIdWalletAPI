using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Test_IndeedIdWallet.Core.Services.Interfaces
{
    public interface ICurrencyService
    {
        Task<bool> IsExists(string currencyCode);
        Task<double> GetConversionRate(string baseCurrency, string targetCurrency);
    }
}
