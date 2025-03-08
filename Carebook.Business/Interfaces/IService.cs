using System.Linq.Expressions;

namespace Carebook.Business.Interfaces
{
    public interface IService<T> where T : class 
    {
        Task<T> GetByIdAsync(int id, bool asNoTracking = true);
        Task<IEnumerable<T>> GetAllAsync(bool asNoTracking = true);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = true);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task Update(T entity);
        Task Remove(T entity);
        Task RemoveRange(IEnumerable<T> entities);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
        Task<IEnumerable<T>> GetPagedResponseAsync(int pageNumber, int pageSize, bool asNoTracking = true);
        IQueryable<T> GetQuery(bool asNoTracking = true);
        
    }
   
}
