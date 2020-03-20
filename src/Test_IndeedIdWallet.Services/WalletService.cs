using System;
using System.Collections.Generic;
using System.Linq;
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
        private ICurrencyService _currencySrv;

        public WalletService(
            IUserService userService,
            IRepository<Wallet> walletRepo,
            ICurrencyService currencySrv)
        {
            _userService = userService;
            _walletRepo = walletRepo;
            _currencySrv = currencySrv;
        }

        public async Task<OperationResult<UserWalletsDTO>> GetUserWalletsAsync(Guid userId)
        {
            var user = _userService.Get(userId);

            var result = new UserWalletsDTO()
            {
                UserId = userId
            };

            if (user == null)
            {
                user = await _userService.CreateUserAsync(userId);
            }
            else
            {
                result.Wallets = _walletRepo.Get(w => w.UserFK.Equals(userId));
            }

            return OperationResultBuilder<UserWalletsDTO>.BuildSuccess(result);
        }

        public async Task<OperationResult<UserWalletsDTO>> ChangeWalletBalanceAsync(UserWalletBalanceOperationDTO userWallet)
        {
            if (!userWallet.UserId.HasValue)
            {
                throw new ArgumentNullException(nameof(userWallet.UserId), "User ID must not be null.");
            }

            var user = _userService.Get(userWallet.UserId.Value);
            if (user == null)
            {
                user = await _userService.CreateUserAsync(userWallet.UserId.Value);
            }

            if (!_currencySrv.IsExists(userWallet.Wallet.Currency))
            {
                return OperationResultBuilder<UserWalletsDTO>
                    .BuildError(null, "Currency does not exist or is not supported.");
            }

            var wallet = _walletRepo.Data
                .FirstOrDefault(w =>
                    w.UserFK.Equals(userWallet.UserId.Value) &&
                    string.Equals(w.CurrencyISOCode, userWallet.Wallet.Currency, StringComparison.InvariantCultureIgnoreCase));

            if (wallet == null)
            {
                wallet = new Wallet()
                {
                    UserFK = userWallet.UserId.Value,
                    Amount = userWallet.Wallet.Amount,
                    CurrencyISOCode = userWallet.Wallet.Currency
                };

                wallet = await _walletRepo.AddAsync(wallet);
            }

            wallet.Amount += userWallet.Wallet.Amount;

            if (wallet.Amount < 0)
            {
                return OperationResultBuilder<UserWalletsDTO>.BuildError(null,
                    "Operation rejected, insufficient funds.");
            }

            wallet = await _walletRepo.UpdateAsync(wallet);

            return await GetUserWalletsAsync(user.Id);
        }

        public async Task<OperationResult<UserWalletsDTO>> ConvertWalletCurrencyAsync(WalletConversionDTO walletConversion)
        {
            throw new NotImplementedException();
        }
    }
}
