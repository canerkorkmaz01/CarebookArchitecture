using Carebook.DataAccess.Context;
using Carebook.DataAccess.Interface;
using Carebook.Entities;
using Microsoft.EntityFrameworkCore;


namespace Carebook.DataAccess.Repositories
{
    public class UserListRepository : IUserListRepository
    {
        private readonly AppDbContext _context;

        public UserListRepository(AppDbContext context)
        {
                _context = context;
        }


        public  async Task<IEnumerable<User>> UserNameAsync()
        {
           return await _context.Users.OrderBy(x => x.UserName).ToListAsync();
        }
    }
}
