using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Test_IndeedIdWallet.Core.Services;
using Test_IndeedIdWallet.Core.Services.Interfaces;

namespace Test_IndeedIdWallet.API
{
    public class ApplicationServiceConfigurator
    {
        public ApplicationServiceConfigurator()
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWalletService, WalletService>();
        }
    }
}
