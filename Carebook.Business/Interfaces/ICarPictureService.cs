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
        Task <IEnumerable<CarPictureViewModel>> CarPictureAsync(int id);
    }
}
