using Carebook.Common.ViewModels;
using Carebook.Entities;

namespace Carebook.DataAccess.Interface
{
    public interface ICarHomeRepository
    {
        Task<IEnumerable<Car>>GetCarHome();
    }
}
