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
    public class CarManagerManager : BaseManager<Car>, ICarManager
    {
        ICarRepository _carRepository;  
        public CarManagerManager(ICarRepository carRepository) : base(carRepository)
        {
            _carRepository = carRepository; 
        }
    }
}
