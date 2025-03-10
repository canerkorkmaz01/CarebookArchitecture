using Carebook.Entities;


namespace Carebook.DataAccess.Interface
{
    public interface IUserListRepository
    {
        Task<IEnumerable<User>> UserNameAsync();
    }
}
