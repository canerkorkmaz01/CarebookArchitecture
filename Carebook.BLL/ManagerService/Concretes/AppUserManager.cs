using Carebook.BLL.ManagerService.Abstracts;
using Carebook.DAL.Repositories.Abstracts;
using Carebook.DAL.Repositories.Concretes;
using Carebook.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carebook.BLL.ManagerService.Concretes
{
    public class AppUserManager : BaseManager<AppUser>, IAppUserManager
    {
        IAppUserRepository _AppUserRepository;

        public AppUserManager(IAppUserRepository AppUserRepository) : base(AppUserRepository)
        {
            _AppUserRepository = AppUserRepository;
        }

        public async Task<bool> CreateUserAsync(AppUser item)
        {
            return await _AppUserRepository.AddUser(item);
        }
    }
}
