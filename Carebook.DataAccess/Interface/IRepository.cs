using Carebook.Entities.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
        void Update(T entity);

        // Veri silmek
        void Remove(T entity);

        // Birden fazla veriyi silmek
        void RemoveRange(IEnumerable<T> entities);

        // Şarta bağlı sayım yapmak
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);

        // Sayfalama
        Task<IEnumerable<T>> GetPagedResponseAsync(int pageNumber, int pageSize, bool asNoTracking = true);

        // IQueryable desteği için
        IQueryable<T> GetQuery(bool asNoTracking = true);
    }
}
