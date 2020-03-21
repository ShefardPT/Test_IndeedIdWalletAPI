﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Test_IndeedIdWallet.Core.Services.Interfaces
{
    public interface ICurrencyService
    {
        bool IsExists(string currencyCode);
        double GetConversionRate(string baseCurrency, string targetCurrency);
    }
}