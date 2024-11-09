using Carebook.Common.ViewModels;
using Carebook.Entities;
using Microsoft.AspNetCore.Identity;

namespace Carebook.Business.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterUserAsync(RegisterViewModel model);
        Task LogoutAsync();
        Task<(SignInResult result, string errorMessage)> LoginUserAsync(LoginViewModel model);
        User GetUserByEmail(string mail);
    }
}
