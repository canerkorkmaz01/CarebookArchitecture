using Carebook.Common.ViewModels;

namespace Carebook.Business.Interfaces
{
    public interface IUserListService
    {
        Task<IEnumerable<UserViewModel>> UserListServices();
    }
}
