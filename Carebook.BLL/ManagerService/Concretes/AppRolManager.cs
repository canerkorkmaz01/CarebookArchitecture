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
    public class AppRolManager : BaseManager<AppRole>,IAppRoleManager
    {
        IAppRoleRepository _appRoleRepository;
        public AppRolManager(IAppRoleRepository appRoleRepository) : base(appRoleRepository)
        {
            _appRoleRepository = appRoleRepository;
        }
    }
}
