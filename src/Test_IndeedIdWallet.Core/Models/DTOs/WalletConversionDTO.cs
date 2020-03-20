using System;

namespace Test_IndeedIdWallet.Core.Models.DTOs
{
    public class WalletConversionDTO
    {
        public Guid? UserId { get; set; }
        public string BaseCurrency { get; set; }
        public string TargetCurrency { get; set; }
        public double Amount { get; set; }
    }
}
