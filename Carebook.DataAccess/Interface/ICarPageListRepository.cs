using Carebook.Common.ViewModels;
using Carebook.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carebook.DataAccess.Interface
{
    public interface ICarPageListRepository
    {
        Task<IPagedList<CarViewModel>> GetPagedCarsAsync(int pageNumber, int pageSize);
    }
}
