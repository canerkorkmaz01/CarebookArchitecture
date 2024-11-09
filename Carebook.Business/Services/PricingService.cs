using Carebook.Business.Interfaces;
using Carebook.DataAccess.Interface;
using Carebook.Entities;
using System.Linq.Expressions;

namespace Carebook.Business.Services
{
    public class PricingService : IService<Pricing>
    {
        private readonly IRepository<Pricing> _pricingRepository;

        public PricingService(IRepository<Pricing> pricingRepository)
        {
            _pricingRepository = pricingRepository;
        }

        public async Task AddAsync(Pricing entity)
        {
            await _pricingRepository.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<Pricing> entities)
        {
            await _pricingRepository.AddRangeAsync(entities);   
        }

        public async Task<int> CountAsync(Expression<Func<Pricing, bool>> predicate = null)
        {
            return await _pricingRepository.CountAsync(predicate);  
        }

        public async Task<IEnumerable<Pricing>> FindAsync(Expression<Func<Pricing, bool>> predicate, bool asNoTracking = true)
        {
           return await _pricingRepository.FindAsync(predicate, asNoTracking);    
        }

        public async Task<IEnumerable<Pricing>> GetAllAsync(bool asNoTracking = true)
        {
           return await _pricingRepository.GetAllAsync(asNoTracking);
        }

        public async Task<Pricing> GetByIdAsync(int id, bool asNoTracking = true)
        {
            return await GetByIdAsync(id, asNoTracking);    
        }

        public async Task<IEnumerable<Pricing>> GetPagedResponseAsync(int pageNumber, int pageSize, bool asNoTracking = true)
        {
           return await _pricingRepository.GetPagedResponseAsync(pageNumber, pageSize, asNoTracking);   
        }

        public  IQueryable<Pricing> GetQuery(bool asNoTracking = true)
        {
           return _pricingRepository.GetQuery(asNoTracking);  
        }

        public void Remove(Pricing entity)
        {
            _pricingRepository.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Pricing> entities)
        {
          _pricingRepository.RemoveRange(entities); 
        }

        public void Update(Pricing entity)
        {
            _pricingRepository.Update(entity);
        }
    }
}
