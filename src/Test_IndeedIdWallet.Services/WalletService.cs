using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test_IndeedIdWallet.Core.Entities;
using Test_IndeedIdWallet.Core.Models;
using Test_IndeedIdWallet.Core.Models.DTOs;
using Test_IndeedIdWallet.Core.Services;
using Test_IndeedIdWallet.Core.Services.Interfaces;
using Test_IndeedIdWallet.Infrastructure.Repositories;

namespace Test_IndeedIdWallet.Services
{
    public class WalletService : IWalletService
    {
        private IUserService _userService;
        private IRepository<Wallet> _walletRepo;
        
        public WalletService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<OperationResult<UserWalletsDTO>> GetUserWalletsAsync(Guid userId)
        {
            var user = _userService.Get(userId);

            var result = new UserWalletsDTO()
            {
                UserId = userId,
                Wallets = new List<Wallet>()
            };

            if (user == null)
            {
                user = await _userService.CreateUserAsync(userId);
            }
            else
            {
                result.Wallets = user.Wallets;
            }

            return OperationResultBuilder<UserWalletsDTO>.BuildSuccess(result);
        }

        public async Task<OperationResult<UserWalletsDTO>> ChangeWalletBalanceAsync(UserWalletBalanceOperationDTO userWallet)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<UserWalletsDTO>> ConvertWalletCurrencyAsync(WalletConversionDTO walletConversion)
        {
            throw new NotImplementedException();
        }
    }
}
