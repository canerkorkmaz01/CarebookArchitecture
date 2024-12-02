using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carebook.DataAccess.Interface
{
    public interface ICarPictureRepository
    {
        Task CarPictureAsync(int id);
        
    }
}
