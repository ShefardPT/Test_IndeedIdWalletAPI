using System;
using System.Linq;
using System.Threading.Tasks;
using Test_IndeedIdWallet.Core.Entities;
using Test_IndeedIdWallet.Core.Services.Interfaces;
using Test_IndeedIdWallet.Infrastructure.Repositories;

namespace Test_IndeedIdWallet.Services
{
    public class UserService : IUserService
    {
        private IRepository<AppUser> _userRepo;

        public UserService(IRepository<AppUser> userRepo)
        {
            _userRepo = userRepo;
        }

        public AppUser Get(Guid userId)
        {
            return _userRepo.Get().FirstOrDefault(u => u.Id.Equals(userId));
        }

        public async Task<AppUser> CreateUserAsync()
        {
            var user = new AppUser();
            user = await _userRepo.AddAsync(user);
            return user;
        }
    }
}
