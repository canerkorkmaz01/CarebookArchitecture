using AutoMapper;
using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Carebook.DataAccess.Interface;
using Carebook.Entities;
using System.Linq.Expressions;

namespace Carebook.Business.Services
{
    public class ReservationService : IService<ReservationViewModel>
    {

        private readonly IRepository<Reservation> _reservationRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ReservationService(IRepository<Reservation> reservationRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(ReservationViewModel viewModel)
        {
          var reservation= _mapper.Map<Reservation>(viewModel);
           await _reservationRepository.AddAsync(reservation);   
           await _unitOfWork.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<ReservationViewModel> viewModel)
        {
            var reservation = _mapper.Map<IEnumerable<Reservation>>(viewModel);
            await _reservationRepository.AddRangeAsync(reservation);   
            await _unitOfWork.SaveChangesAsync();   
        }

        public async Task<int> CountAsync(Expression<Func<ReservationViewModel, bool>> predicate = null)
        {
            Expression<Func<Reservation, bool>> reservationPredicate = _mapper.Map<Expression<Func<ReservationViewModel, bool>>, Expression<Func<Reservation, bool>>>(predicate);
            return await _reservationRepository.CountAsync(reservationPredicate);   
        }

        public async Task<IEnumerable<ReservationViewModel>> FindAsync(Expression<Func<ReservationViewModel, bool>> predicate, bool asNoTracking = true)
        {
            Expression<Func<Reservation, bool>> carPredicate = _mapper.Map<Expression<Func<ReservationViewModel, bool>>, Expression<Func<Reservation, bool>>>(predicate);
            var reservations = await _reservationRepository.FindAsync(carPredicate, asNoTracking);
            return _mapper.Map<IEnumerable<ReservationViewModel>>(reservations);
        }

        public async Task<IEnumerable<ReservationViewModel>> GetAllAsync(bool asNoTracking = true)
        {
            var reservation = await _reservationRepository.GetAllAsync(asNoTracking);
            return _mapper.Map<IEnumerable<ReservationViewModel>>(reservation);
        }

        public async Task<ReservationViewModel> GetByIdAsync(int id, bool asNoTracking = true)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id, asNoTracking);
            return _mapper.Map<ReservationViewModel>(reservation);
        }

        public async Task<IEnumerable<ReservationViewModel>> GetPagedResponseAsync(int pageNumber, int pageSize, bool asNoTracking = true)
        {
            var reservation= await _reservationRepository.GetPagedResponseAsync(pageNumber, pageSize, asNoTracking);
            return _mapper.Map<IEnumerable<ReservationViewModel>>(reservation);
        }

        public IQueryable<ReservationViewModel> GetQuery(bool asNoTracking = true)
        {
            var reservation = _reservationRepository.GetQuery(asNoTracking);
            var reservationList = reservation.ToList();
            var reservationModelView = _mapper.Map<IEnumerable<ReservationViewModel>>(reservation);
            return reservationModelView.AsQueryable();
        }

        public async Task Remove(ReservationViewModel viewModel)
        {
            var pricingviewmodel = _mapper.Map<Reservation>(viewModel);
            await _reservationRepository.Remove(pricingviewmodel);
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task RemoveRange(IEnumerable<ReservationViewModel> viewModel)
        {

            var pricingviewmodel = _mapper.Map<IEnumerable<Reservation>>(viewModel);
            await _reservationRepository.RemoveRange(pricingviewmodel);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Update(ReservationViewModel viewModel)
        {
            var pricingviewmodel = _mapper.Map<Reservation>(viewModel);
            await _reservationRepository.Update(pricingviewmodel);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
