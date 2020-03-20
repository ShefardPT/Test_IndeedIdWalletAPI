using System;

namespace Test_IndeedIdWallet.Core.Models.DTOs
{
    public class UserWalletBalanceOperationDTO
    {
        public Guid? UserId { get; set; }
        public WalletDTO Wallet { get; set; }
    }
}
