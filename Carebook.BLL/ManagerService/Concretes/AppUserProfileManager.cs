using Carebook.BLL.ManagerService.Abstracts;
using Carebook.DAL.Repositories.Abstracts;
using Carebook.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carebook.BLL.ManagerService.Concretes
{
    public class AppUserProfileManager : BaseManager<AppUserProfile>, IAppUserProfileManager
    {
        IAppUserProfileRepository _appUserProfileRepository;

        public AppUserProfileManager(IAppUserProfileRepository appUserProfileRepository) : base(appUserProfileRepository)
        {
            _appUserProfileRepository=appUserProfileRepository;
        }
    }
}
