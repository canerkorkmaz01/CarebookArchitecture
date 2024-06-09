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
    public class PricingManager : BaseManager<Pricing>, IPricingManager
    {
        IPricingRepository _pricingRepository;
        public PricingManager(IPricingRepository pricingRepository) : base(pricingRepository)
        {
            _pricingRepository = pricingRepository; 
        }
    }
}
