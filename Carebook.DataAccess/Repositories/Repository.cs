using Carebook.DataAccess.Context;
using Carebook.DataAccess.Interface;
using Carebook.Entities.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Carebook.DataAccess.Repositories
{
    public class Repository<T>: IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id, bool asNoTracking = true)
        {
            return asNoTracking
                ? await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id)
                : await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool asNoTracking = true)
        {
            return asNoTracking
                ? await _dbSet.AsNoTracking().ToListAsync()
                : await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = true)
        {
            return asNoTracking
                ? await _dbSet.AsNoTracking().Where(predicate).ToListAsync()
                : await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task Remove(T entity)
        {
           _dbSet.Remove(entity);
        }

        public async Task RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null
                ? await _dbSet.CountAsync()
                : await _dbSet.CountAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetPagedResponseAsync(int pageNumber, int pageSize, bool asNoTracking = true)
        {
            return asNoTracking
                ? await _dbSet.AsNoTracking().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync()
                : await _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public IQueryable<T> GetQuery(bool asNoTracking = true)
        {
            return asNoTracking ? _dbSet.AsNoTracking() : _dbSet;
        }
    }
}
