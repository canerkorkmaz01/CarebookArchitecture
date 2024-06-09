using Carebook.DAL.Context;
using Carebook.DAL.Repositories.Abstracts;
using Carebook.ENTITIES.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carebook.DAL.Repositories.Concretes
{
    public class AppUserRepository :BaseRepository<AppUser>,IAppUserRepository
    {
        UserManager<AppUser> _userManager;
        public AppUserRepository(AppDbContex appDbContex, UserManager<AppUser> userManager) :base(appDbContex)
        {
            _userManager = userManager;
        }

        public async Task<bool> AddUser(AppUser item)
        {
            IdentityResult result = await _userManager.CreateAsync(item, item.PasswordHash);

            if (result.Succeeded) return true;
            //List<IdentityError> errors = new List<IdentityError>();
            //foreach (IdentityError error in result.Errors)
            //{
            //    errors.Add(error);
            //}
            return false;
        }
    }
}
