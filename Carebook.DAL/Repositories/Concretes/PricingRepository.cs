using Carebook.DAL.Context;
using Carebook.DAL.Repositories.Abstracts;
using Carebook.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carebook.DAL.Repositories.Concretes
{
    public class PricingRepository : BaseRepository<Pricing>,IPricingRepository
    {
        public PricingRepository(AppDbContex appDbContex) :base(appDbContex)
        {
                
        }

    }
    
}
