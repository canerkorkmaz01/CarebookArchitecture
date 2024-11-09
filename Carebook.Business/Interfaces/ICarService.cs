using Carebook.Entities;
using System.Linq.Expressions;

namespace Carebook.Business.Interfaces
{
    public interface ICarService
    {
        //Task<IEnumerable<TResult>> GetCarsAsync<TResult>(Expression<Func<Car, TResult>> selector);

        Task<IEnumerable<TResult>> GetCarsAsync<TResult>(Expression<Func<Car, TResult>> selector, Func<IQueryable<TResult>, IOrderedQueryable<TResult>> orderBy = null);
    }
}
