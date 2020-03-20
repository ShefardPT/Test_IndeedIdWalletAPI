using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Test_IndeedIdWallet.Core.Entities;
using Test_IndeedIdWallet.Core.Services;
using Test_IndeedIdWallet.Core.Services.Interfaces;
using Test_IndeedIdWallet.Infrastructure.Repositories;

namespace Test_IndeedIdWallet.API
{
    public class ApplicationServiceConfigurator
    {
        public ApplicationServiceConfigurator()
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            #region Services

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWalletService, WalletService>();

            #endregion

            #region Repositories

            services.AddScoped<IRepository<AppUser>, DbRepository<AppUser>>();
            services.AddScoped<IRepository<Wallet>, DbRepository<Wallet>>();

            #endregion
        }
    }
}
