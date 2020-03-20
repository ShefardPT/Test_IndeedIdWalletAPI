using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Test_IndeedIdWallet.Core.Entities
{
    public class Wallet : Entity
    {
        [Required]
        public string CurrencyISOCode { get; set; }

        public double Amount { get; set; }

        // Relations
        [ForeignKey("UserFK")]
        public AppUser User { get; set; }
        public Guid UserFK { get; set; }
    }
}
