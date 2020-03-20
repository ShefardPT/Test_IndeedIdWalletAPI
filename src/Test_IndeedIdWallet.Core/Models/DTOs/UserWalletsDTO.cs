using System;
using System.Collections.Generic;
using Test_IndeedIdWallet.Core.Entities;

namespace Test_IndeedIdWallet.Core.Models.DTOs
{
    public class UserWalletsDTO
    {
        public Guid? UserId { get; set; }
        public ICollection<Wallet> Wallets { get; set; }
    }
}
