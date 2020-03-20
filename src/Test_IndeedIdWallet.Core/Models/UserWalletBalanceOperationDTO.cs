using System;
using System.Collections.Generic;
using System.Text;

namespace Test_IndeedIdWallet.Core.Models
{
    public class UserWalletBalanceOperationDTO
    {
        public Guid? UserId { get; set; }
        public WalletDTO Wallet { get; set; }
    }
}
