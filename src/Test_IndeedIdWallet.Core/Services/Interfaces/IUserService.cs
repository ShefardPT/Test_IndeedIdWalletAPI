using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test_IndeedIdWallet.Core.Entities;

namespace Test_IndeedIdWallet.Core.Services.Interfaces
{
    public interface IUserService
    {
        AppUser Get(Guid userId);
        Task<AppUser> CreateUserAsync();
    }
}
