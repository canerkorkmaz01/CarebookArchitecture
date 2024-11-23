using Carebook.Business.Interfaces;
using Carebook.DataAccess.Interface;
using Carebook.Entities;
using System.Linq.Expressions;

namespace Carebook.Business.Services
{
    public class CarPictureService : IService<CarPicture>
    {
        private readonly IRepository<CarPicture> _carPictureRepository;

        public CarPictureService(IRepository<CarPicture> carPictureRepository)
        {
            _carPictureRepository = carPictureRepository;
        }

        public async Task AddAsync(CarPicture entity)
        {
            await _carPictureRepository.AddAsync(entity);  
        }

        public async Task AddRangeAsync(IEnumerable<CarPicture> entities)
        {
            await _carPictureRepository.AddRangeAsync(entities);
        }

        public async Task<int> CountAsync(Expression<Func<CarPicture, bool>> predicate = null)
        {
            return await _carPictureRepository.CountAsync(predicate); 
        }

        public async Task<IEnumerable<CarPicture>> FindAsync(Expression<Func<CarPicture, bool>> predicate, bool asNoTracking = true)
        {
            return await _carPictureRepository.FindAsync(predicate, asNoTracking);
        }

        public async Task<IEnumerable<CarPicture>> GetAllAsync(bool asNoTracking = true)
        {
            return await _carPictureRepository.GetAllAsync(asNoTracking); 
        }

        public async Task<CarPicture> GetByIdAsync(int id, bool asNoTracking = true)
        {
            return  await _carPictureRepository.GetByIdAsync(id, asNoTracking);
        }

        public Task<IEnumerable<TResult>> GetCarsAsync<TResult>(Expression<Func<Car, TResult>> selector)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CarPicture>> GetPagedResponseAsync(int pageNumber, int pageSize, bool asNoTracking = true)
        {
            return await _carPictureRepository.GetPagedResponseAsync(pageNumber, pageSize, asNoTracking);
        }

        public IQueryable<CarPicture> GetQuery(bool asNoTracking = true)
        {
            return _carPictureRepository.GetQuery(asNoTracking);
        }

        public async Task Remove(CarPicture entity)
        {
            await _carPictureRepository.Remove(entity);
        }

        public async Task RemoveRange(IEnumerable<CarPicture> entities)
        {
            await _carPictureRepository.RemoveRange(entities);
        }

        public async Task Update(CarPicture entity)
        {
           await _carPictureRepository.Update(entity);
        }
    }
}
