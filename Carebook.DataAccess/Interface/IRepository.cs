using Carebook.Entities.Infrastructure;
using System.Linq.Expressions;

namespace Carebook.DataAccess.Interface
{
    public interface IRepository<T> where T: BaseEntity
    {
        // Id ile veri almak
        Task<T> GetByIdAsync(int id, bool asNoTracking = true);

        // Tüm verileri almak
        Task<IEnumerable<T>> GetAllAsync(bool asNoTracking = true);

        // Şartlı veri çekmek (Örneğin filtreleme)
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = true);

        // Yeni veri eklemek
        Task AddAsync(T entity);

        // Birden fazla veri eklemek
        Task AddRangeAsync(IEnumerable<T> entities);

        // Veri güncellemek
        Task Update(T entity);

        // Veri silmek
        Task Remove(T entity);

        // Birden fazla veriyi silmek
        Task RemoveRange(IEnumerable<T> entities);

        // Şarta bağlı sayım yapmak
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);

        // Sayfalama
        Task<IEnumerable<T>> GetPagedResponseAsync(int pageNumber, int pageSize, bool asNoTracking = true);

        // IQueryable desteği için
        IQueryable<T> GetQuery(bool asNoTracking = true);
    }
}
