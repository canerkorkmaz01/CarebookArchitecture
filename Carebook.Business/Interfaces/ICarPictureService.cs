using Carebook.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carebook.Business.Interfaces
{
    public interface ICarPictureService
    {
        Task <List<CarPictureViewModel>> CarPictureAsync(int id);
    }
}
