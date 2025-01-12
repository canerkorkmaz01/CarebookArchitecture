using Carebook.Common.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Carebook.Business.Interfaces
{
    public interface ICarDropdownListService
    {
        Task<List<CarViewModel>> GetCarDropdownlist();
    }
}
