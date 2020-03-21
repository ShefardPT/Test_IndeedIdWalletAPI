using System;
using System.Collections.Generic;
using System.Text;
using Test_IndeedIdWallet.Core.Services.Interfaces;

namespace Test_IndeedIdWallet.Services
{
    public class CurrencyService : ICurrencyService
    {
        public bool IsExists(string currencyCode)
        {
            throw new NotImplementedException();
        }

        public double GetConversionRate(string baseCurrency, string targetCurrency)
        {
            throw new NotImplementedException();
        }
    }
}
