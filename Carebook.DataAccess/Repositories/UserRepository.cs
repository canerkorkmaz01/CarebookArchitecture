using Carebook.DataAccess.Context;
using Carebook.DataAccess.Interface;
using Carebook.Entities;
using Microsoft.EntityFrameworkCore;

namespace Carebook.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _userRepository;

        public UserRepository(AppDbContext userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddAsync(User user)
        {
            await _userRepository.AddAsync(user);   
        }

        public async Task<IEnumerable<User>> GetAllAsync(bool asNoTracking = true)
        {
            return await (asNoTracking ? _userRepository.Users.AsNoTracking() : _userRepository.Users).ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id, bool asNoTracking = true)
        {
            return await (asNoTracking ? _userRepository.Users.AsNoTracking() : _userRepository.Users).FirstOrDefaultAsync(u => u.Id == id);
        }


        public void Remove(User user)
        {
            _userRepository.Remove(user);
        }

        public void Update(User user)
        {
           _userRepository.Update(user);    
        }
    }
}
