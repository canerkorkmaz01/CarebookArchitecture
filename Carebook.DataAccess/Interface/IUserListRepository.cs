using Carebook.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carebook.DataAccess.Interface
{
    public interface IUserListRepository
    {
        Task<IEnumerable<User>> UserNameAsync();
    }
}
