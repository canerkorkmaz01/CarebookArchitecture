using Carebook.Common.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carebook.Business.Interfaces
{
    public interface IFeatureService
    {
        Task <List<FeatureViewModel>>GetAllNameFeatures();

        Task<List<FeatureViewModel>> GetAllAsync();

    }
}
