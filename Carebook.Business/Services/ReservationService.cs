using Carebook.Business.Interfaces;
using Carebook.DataAccess.Interface;
using Carebook.Entities;
using System.Linq.Expressions;

namespace Carebook.Business.Services
{
    public class ReservationService : IService<Reservation>
    {

        private readonly IRepository<Reservation> _reservationRepository;

        public ReservationService(IRepository<Reservation> reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task AddAsync(Reservation entity)
        {
           await _reservationRepository.AddAsync(entity);   
        }

        public async Task AddRangeAsync(IEnumerable<Reservation> entities)
        {
            await _reservationRepository.AddRangeAsync(entities);   
        }

        public async Task<int> CountAsync(Expression<Func<Reservation, bool>> predicate = null)
        {
           return await _reservationRepository.CountAsync(predicate);   
        }

        public async Task<IEnumerable<Reservation>> FindAsync(Expression<Func<Reservation, bool>> predicate, bool asNoTracking = true)
        {
           return await _reservationRepository.FindAsync(predicate, asNoTracking);
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync(bool asNoTracking = true)
        {
            return await _reservationRepository.GetAllAsync(asNoTracking);  
        }

        public async Task<Reservation> GetByIdAsync(int id, bool asNoTracking = true)
        {
            return await _reservationRepository.GetByIdAsync(id,  asNoTracking);
        }

        public async Task<IEnumerable<Reservation>> GetPagedResponseAsync(int pageNumber, int pageSize, bool asNoTracking = true)
        {
            return await _reservationRepository.GetPagedResponseAsync(pageNumber, pageSize, asNoTracking);  
        }

        public IQueryable<Reservation> GetQuery(bool asNoTracking = true)
        {
            return _reservationRepository.GetQuery(asNoTracking);
        }

        public void Remove(Reservation entity)
        {
            _reservationRepository.Remove(entity);  
        }

        public void RemoveRange(IEnumerable<Reservation> entities)
        {
            _reservationRepository.RemoveRange(entities);   
        }

        public void Update(Reservation entity)
        {
            _reservationRepository.Update(entity);  
        }
    }
}
