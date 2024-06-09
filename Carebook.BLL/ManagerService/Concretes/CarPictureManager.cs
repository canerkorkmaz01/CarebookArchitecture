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
    public class CarPictureManager : BaseManager<CarPicture>, ICarPictureManager
    {
        ICarPictureRepository _carRepository;
        public CarPictureManager(ICarPictureRepository carRepository) : base(carRepository)
        {
            _carRepository = carRepository; 
        }
    }
}
