
using Carebook.DataAccess.Interface;
using Carebook.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Carebook.DataAccess.Repositories
{
    public class UserListRepository : IUserListRepository
    {
        private readonly UserManager<User> _userManager;

        public UserListRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public  async Task<IEnumerable<User>> UserNameAsync()
        {
           return await _userManager.Users.OrderBy(x => x.UserName).ToListAsync();
        }
    }
}
