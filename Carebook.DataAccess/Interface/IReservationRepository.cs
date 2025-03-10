using Carebook.Common.ViewModels;
using Carebook.Entities;


namespace Carebook.DataAccess.Interface
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetReservationNameAsync();

        Task<IEnumerable<Car>> GetReservationAsync();
    }
}
