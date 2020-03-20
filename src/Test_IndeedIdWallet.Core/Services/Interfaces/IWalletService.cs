using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test_IndeedIdWallet.Core.Models;
using Test_IndeedIdWallet.Core.Models.DTOs;

namespace Test_IndeedIdWallet.Core.Services.Interfaces
{
    public interface IWalletService
    {
        Task<OperationResult<UserWalletsDTO>> GetUserWalletsAsync(Guid userId);
        Task<OperationResult<UserWalletsDTO>> ChangeWalletBalanceAsync(UserWalletBalanceOperationDTO userWallet);
        Task<OperationResult<UserWalletsDTO>> ConvertWalletCurrencyAsync(WalletConversionDTO walletConversion);
    }
}
