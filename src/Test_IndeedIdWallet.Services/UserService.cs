using System;
using System.Threading.Tasks;
using Test_IndeedIdWallet.Core.Entities;
using Test_IndeedIdWallet.Core.Services.Interfaces;

namespace Test_IndeedIdWallet.Services
{
    public class UserService : IUserService
    {
        public AppUser Get(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<AppUser> CreateUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
