using System.Collections;
using System.Collections.Generic;

namespace Test_IndeedIdWallet.Core.Entities
{
    public class AppUser : Entity
    {
        // Relations
        public ICollection<Wallet> Wallets { get; set; }
    }
}
