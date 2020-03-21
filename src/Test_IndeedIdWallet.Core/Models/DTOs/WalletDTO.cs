namespace Test_IndeedIdWallet.Core.Models.DTOs
{
    public class WalletDTO
    {
        private string _currency;

        public string Currency
        {
            get => _currency;
            set => _currency = value.ToUpperInvariant();
        }

        public double Amount { get; set; }
    }
}
