using System;
using System.Collections.Generic;
using System.Text;
using Test_IndeedIdWallet.Core.Entities;

namespace Test_IndeedIdWallet.Core.Models
{
    public class UserWalletsDTO
    {
        public Guid? UserId { get; set; }
        public IEnumerable<WalletDTO> Wallets { get; set; }
    }
}
