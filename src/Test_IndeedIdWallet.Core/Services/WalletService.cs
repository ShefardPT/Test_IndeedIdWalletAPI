using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test_IndeedIdWallet.Core.Models;
using Test_IndeedIdWallet.Core.Services.Interfaces;

namespace Test_IndeedIdWallet.Core.Services
{
    public class WalletService : IWalletService
    {
        public async Task<UserWalletsDTO> GetUserWalletsAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<UserWalletsDTO> ChangeWalletBalanceAsync(UserWalletBalanceOperationDTO userWallet)
        {
            throw new NotImplementedException();
        }

        public async Task<UserWalletsDTO> ConvertWalletCurrencyAsync(WalletConversionDTO walletConversion)
        {
            throw new NotImplementedException();
        }
    }
}
