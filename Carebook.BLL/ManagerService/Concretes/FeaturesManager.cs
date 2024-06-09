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
    public class FeaturesManager : BaseManager<Feature>, IFeaturesManager
    {
        IFeaturesRepository _featuresRepository;
        public FeaturesManager(IFeaturesRepository featuresRepository) : base(featuresRepository)
        {
            _featuresRepository = featuresRepository;   
        }
    }
}
