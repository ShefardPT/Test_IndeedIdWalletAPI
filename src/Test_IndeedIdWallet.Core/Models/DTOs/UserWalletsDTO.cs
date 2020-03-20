using System;
using System.Collections.Generic;

namespace Test_IndeedIdWallet.Core.Models.DTOs
{
    public class UserWalletsDTO
    {
        public Guid? UserId { get; set; }
        public IEnumerable<WalletDTO> Wallets { get; set; }
    }
}
