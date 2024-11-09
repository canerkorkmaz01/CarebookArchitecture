using Carebook.Entities;

namespace Carebook.DataAccess.Interface
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id, bool asNoTracking = true);
        Task<IEnumerable<User>> GetAllAsync(bool asNoTracking = true);
        Task AddAsync(User user);
        void Update(User user);
        void Remove(User user);
    }
}
