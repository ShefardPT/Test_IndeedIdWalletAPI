using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test_IndeedIdWallet.Core.Models;
using Test_IndeedIdWallet.Core.Models.DTOs;
using Test_IndeedIdWallet.Core.Services.Interfaces;

namespace Test_IndeedIdWallet.API.Controllers
{
    [Route("api/wallet")]
    public class WalletController : Controller
    {
        private IWalletService _walletSrv;

        public WalletController(IWalletService walletSrv)
        {
            _walletSrv = walletSrv;
        }

        [HttpGet]
        public async Task<IActionResult> GetWalletStatus(Guid? userId)
        {
            if (!userId.HasValue)
            {
                return BadRequest("User ID was not set.");
            }

            var result = await _walletSrv.GetUserWalletsAsync(userId.Value);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeWalletsBalance([FromBody] UserWalletBalanceOperationDTO userWallet)
        {
            if (userWallet == null || 
                !userWallet.UserId.HasValue)
            {
                return BadRequest("Invalid model.");
            }

            var result = await _walletSrv.ChangeWalletBalanceAsync(userWallet);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("convert")]
        public async Task<IActionResult> ConvertWalletCurrency([FromBody] WalletConversionDTO walletConversion)
        {
            if (walletConversion == null ||
                !walletConversion.UserId.HasValue ||
                walletConversion.Amount <= 0)
            {
                return BadRequest("Invalid model.");
            }

            var result = await _walletSrv.ConvertWalletCurrencyAsync(walletConversion);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
