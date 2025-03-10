using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Carebook.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Claims;

namespace Carebook.Business.Services
{

    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager; 
        }

        public User GetUserByEmail(string email)
        {
            return _userManager.Users.FirstOrDefault(u => u.Email == email);
        }
       
        public async Task<(SignInResult result, string errorMessage)> LoginUserAsync(LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null || !user.Enabled)
            {
                return (SignInResult.Failed, "Yasaklı veya geçersiz kullanıcı girişi.");
            }
            var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, true);

            if (!result.Succeeded)
            {
                return (result, "Geçersiz kullanıcı girişi.");
            }

            // Başarılı giriş
            return (result, null);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterViewModel model)
        {
            var newUser = new User
            {
                UserName = model.Email,
                Name = model.Name,
                Email = model.Email,
                Gender = model.Gender,
                EmailConfirmed = false
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
              
                return result;
            }

            await _userManager.AddClaimAsync(newUser, new Claim("FullName", newUser.Name));

            var roleExist = await _roleManager.RoleExistsAsync("Staff");

            if (!roleExist)
            {
                var role = new Role { Name = "Staff", DisplayName = "Staff Member" };
                var createRoleResult = await _roleManager.CreateAsync(role);

                if (!createRoleResult.Succeeded)
                {
                    return IdentityResult.Failed(new IdentityError { Description = "Staff rolü oluşturulamadı." });
                }
            }

            await _userManager.AddToRoleAsync(newUser, "Staff");

            return result;
        }



    }
}
