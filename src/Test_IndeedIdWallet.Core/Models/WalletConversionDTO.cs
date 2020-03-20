using System;
using System.Collections.Generic;
using System.Text;

namespace Test_IndeedIdWallet.Core.Models
{
    public class WalletConversionDTO
    {
        public Guid? UserId { get; set; }
        public string BaseCurrency { get; set; }
        public string TargetCurrency { get; set; }
        public double Amount { get; set; }
    }
}
