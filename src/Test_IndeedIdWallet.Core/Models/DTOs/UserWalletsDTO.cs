using System;
using System.Collections.Generic;
using Test_IndeedIdWallet.Core.Entities;

namespace Test_IndeedIdWallet.Core.Models.DTOs
{
    public class UserWalletsDTO
    {
        public UserWalletsDTO()
        {
            Wallets = new Wallet[0];
        }

        public Guid? UserId { get; set; }
        public IEnumerable<Wallet> Wallets { get; set; }
    }
}
