using Carebook.Common.ViewModels;

namespace Carebook.Business.Interfaces
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationViewModel>> ReservationList();
    }
}
