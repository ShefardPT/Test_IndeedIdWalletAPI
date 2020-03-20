using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test_IndeedIdWallet.Core.Models;

namespace Test_IndeedIdWallet.Core.Services.Interfaces
{
    public interface IWalletService
    {
        Task<UserWalletsDTO> GetUserWalletsAsync(Guid userId);
        Task<UserWalletsDTO> ChangeWalletBalanceAsync(UserWalletBalanceOperationDTO userWallet);
        Task<UserWalletsDTO> ConvertWalletCurrencyAsync(WalletConversionDTO walletConversion);
    }
}
