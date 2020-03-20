using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Test_IndeedIdWallet.Core.Entities;

namespace Test_IndeedIdWallet.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        protected ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // One-to-many relation of User and Wallets
            builder.Entity<AppUser>()
                .HasMany<Wallet>()
                .WithOne(w => w.User)
                .HasForeignKey(w => w.UserFK)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
