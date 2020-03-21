using System;

namespace Test_IndeedIdWallet.Core.Models.DTOs
{
    public class WalletConversionDTO
    {
        private string _baseCurrency;
        private string _targetCurrency;
        public Guid? UserId { get; set; }

        public string BaseCurrency
        {
            get => _baseCurrency;
            set => _baseCurrency = value.ToUpperInvariant();
        }

        public string TargetCurrency
        {
            get => _targetCurrency;
            set => _targetCurrency = value.ToUpperInvariant();
        }

        public double Amount { get; set; }
    }
}
