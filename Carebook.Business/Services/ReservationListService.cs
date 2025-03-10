using AutoMapper;
using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Carebook.DataAccess.Interface;


namespace Carebook.Business.Services
{
    public class ReservationListService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;
        public ReservationListService(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarViewModel>> ReservationCarList()
        {
            var reservationcar = await _reservationRepository.GetReservationAsync();
     
            return _mapper.Map<IEnumerable<CarViewModel>>(reservationcar);

        }

        public async Task<IEnumerable<ReservationViewModel>> ReservationList()
        {
            var reservation = await _reservationRepository.GetReservationNameAsync();
            
            return _mapper.Map<IEnumerable<ReservationViewModel>>(reservation);  
        }
    }
}
