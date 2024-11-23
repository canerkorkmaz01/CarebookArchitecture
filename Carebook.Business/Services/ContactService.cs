using Carebook.Business.Interfaces;
using Carebook.DataAccess.Interface;
using Carebook.Entities;
using System.Linq.Expressions;

namespace Carebook.Business.Services
{
    public class ContactService : IService<Contact>
    {
        private readonly IRepository<Contact> _contactRepository;

        public ContactService(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task AddAsync(Contact entity)
        {
            await _contactRepository.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<Contact> entities)
        {
            await _contactRepository.AddRangeAsync(entities);   
        }

        public async Task<int> CountAsync(Expression<Func<Contact, bool>> predicate = null)
        {
           return await _contactRepository.CountAsync(predicate);
        }

        public async Task<IEnumerable<Contact>> FindAsync(Expression<Func<Contact, bool>> predicate, bool asNoTracking = true)
        {
            return await _contactRepository.FindAsync(predicate, asNoTracking);
        }

        public async Task<IEnumerable<Contact>> GetAllAsync(bool asNoTracking = true)
        {
           return await _contactRepository.GetAllAsync(asNoTracking);
        }

        public async Task<Contact> GetByIdAsync(int id, bool asNoTracking = true)
        {
            return await _contactRepository.GetByIdAsync(id, asNoTracking); 
        }
 
        public async Task<IEnumerable<Contact>> GetPagedResponseAsync(int pageNumber, int pageSize, bool asNoTracking = true)
        {
           return await _contactRepository.GetPagedResponseAsync(pageNumber, pageSize, asNoTracking);   
        }

        public  IQueryable<Contact> GetQuery(bool asNoTracking = true)
        {
           return _contactRepository.GetQuery(asNoTracking);    
        }

        public async Task Remove(Contact entity)
        {
            await _contactRepository.Remove(entity);
        }

        public async Task RemoveRange(IEnumerable<Contact> entities)
        {
           await _contactRepository.RemoveRange(entities);   
        }

        public async Task Update(Contact entity)
        {
           await _contactRepository.Update(entity);  
        }
    }
}
