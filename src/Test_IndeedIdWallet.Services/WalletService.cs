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

        public async Task<OperationResult<UserWalletsDTO>> GetUserWalletsAsync
            (Guid userId)
        {
            var result = new UserWalletsDTO();

            var user = _userService.Get(userId);

            if (user != null)
            {
                result.Wallets = _walletRepo
                    .Get(w => w.UserFK.Equals(user.Id))
                    .Select(w => new WalletDTO()
                    {
                        Currency = w.CurrencyISOCode,
                        Amount = w.Amount
                    });
            }
            else
            {
                user = await _userService.CreateUserAsync();
            }

            result.UserId = user.Id;

            return OperationResultBuilder<UserWalletsDTO>.BuildSuccess(result);
        }

        public async Task<OperationResult<UserWalletsDTO>> ChangeWalletBalanceAsync
            (UserWalletBalanceOperationDTO userWallet)
        {
            if (!userWallet.UserId.HasValue)
            {
                throw new ArgumentNullException(nameof(userWallet.UserId), "User ID must not be null.");
            }

            var user = _userService.Get(userWallet.UserId.Value);
            if (user == null)
            {
                user = await _userService.CreateUserAsync();
            }

            if (!await _currencySrv.IsExists(userWallet.Wallet.Currency))
            {
                return OperationResultBuilder<UserWalletsDTO>
                    .BuildError(null, "Currency does not exist or is not supported.");
            }

            var wallet = _walletRepo.Data
                .FirstOrDefault(w =>
                    w.UserFK.Equals(user.Id) &&
                    string.Equals(w.CurrencyISOCode, userWallet.Wallet.Currency, StringComparison.InvariantCultureIgnoreCase));

            if (wallet == null)
            {
                wallet = new Wallet()
                {
                    UserFK = user.Id,
                    Amount = 0,
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

        public async Task<OperationResult<UserWalletsDTO>> ConvertWalletCurrencyAsync
            (WalletConversionDTO walletConversion)
        {
            if (!walletConversion.UserId.HasValue)
            {
                throw new ArgumentNullException(nameof(walletConversion.UserId), "User ID must not be null.");
            }

            var user = _userService.Get(walletConversion.UserId.Value);
            if (user == null)
            {
                user = await _userService.CreateUserAsync();
                return OperationResultBuilder<UserWalletsDTO>.BuildError(null,
                    "New user does not have actual wallets.");
            }

            if (!await _currencySrv.IsExists(walletConversion.BaseCurrency) ||
               !await _currencySrv.IsExists(walletConversion.TargetCurrency))
            {
                return OperationResultBuilder<UserWalletsDTO>.BuildError(null,
                    "Currency does not exist or is not supported.");
            }

            var baseWallet = _walletRepo.Data
                .FirstOrDefault(w =>
                    w.UserFK.Equals(user.Id) &&
                    string.Equals(w.CurrencyISOCode, walletConversion.BaseCurrency,
                        StringComparison.InvariantCultureIgnoreCase));

            if (baseWallet == null)
            {
                return OperationResultBuilder<UserWalletsDTO>.BuildError(null, "Base wallet does not exist.");
            }

            var targetWallet = _walletRepo.Data
                .FirstOrDefault(w =>
                    w.UserFK.Equals(user.Id) &&
                    string.Equals(w.CurrencyISOCode, walletConversion.TargetCurrency,
                        StringComparison.InvariantCultureIgnoreCase));

            if (targetWallet == null)
            {
                targetWallet = new Wallet()
                {
                    UserFK = user.Id,
                    CurrencyISOCode = walletConversion.TargetCurrency
                };

                await _walletRepo.AddAsync(targetWallet);
            }

            var conversionRate = await _currencySrv.GetConversionRate
                (walletConversion.BaseCurrency, walletConversion.TargetCurrency);

            var targetCurrencyAmount = walletConversion.Amount * conversionRate;

            baseWallet.Amount -= walletConversion.Amount;
            targetWallet.Amount += targetCurrencyAmount;
            await _walletRepo.UpdateAsync(new[] { baseWallet, targetWallet });

            return await GetUserWalletsAsync(user.Id);
        }
    }
}
