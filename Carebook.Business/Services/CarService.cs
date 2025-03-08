using AutoMapper;
using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Carebook.DataAccess.Interface;
using Carebook.Entities;
using System.Linq.Expressions;

namespace Carebook.Business.Services
{
    public class CarService : IService<CarViewModel>
    {

       private readonly IRepository<Car> _carRepository;
       private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CarService(IRepository<Car> carRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _carRepository = carRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(CarViewModel viewModel)
        {
            var car = _mapper.Map<Car>(viewModel);
            await _carRepository.AddAsync(car);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<CarViewModel> viewModels)
        {
            var cars = _mapper.Map<IEnumerable<Car>>(viewModels); 
            await _carRepository.AddRangeAsync(cars);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> CountAsync(Expression<Func<CarViewModel, bool>> predicate = null)
        {
            Expression<Func<Car, bool>> carPredicate = _mapper.Map<Expression<Func<CarViewModel, bool>>, Expression<Func<Car, bool>>>(predicate);
            return await _carRepository.CountAsync(carPredicate);
        }

        public async Task<IEnumerable<CarViewModel>> FindAsync(Expression<Func<CarViewModel, bool>> predicate, bool asNoTracking = true)
        {
            Expression<Func<Car, bool>> carPredicate = _mapper.Map<Expression<Func<CarViewModel, bool>>, Expression<Func<Car, bool>>>(predicate);
            var cars = await _carRepository.FindAsync(carPredicate, asNoTracking);
            return _mapper.Map<IEnumerable<CarViewModel>>(cars); 
        }

        public async Task<IEnumerable<CarViewModel>> GetAllAsync(bool asNoTracking = true)
        {
            var cars = await _carRepository.GetAllAsync(asNoTracking);
            return _mapper.Map<IEnumerable<CarViewModel>>(cars);
        }

        public async Task<CarViewModel> GetByIdAsync(int id, bool asNoTracking = true)
        {
            var car = await _carRepository.GetByIdAsync(id, asNoTracking);
            return _mapper.Map<CarViewModel>(car); 
        }

        public async Task<IEnumerable<CarViewModel>> GetPagedResponseAsync(int pageNumber, int pageSize, bool asNoTracking = true)
        {
            var cars = await _carRepository.GetPagedResponseAsync(pageNumber, pageSize, asNoTracking);
            return _mapper.Map<IEnumerable<CarViewModel>>(cars); 
        }

        public IQueryable<CarViewModel> GetQuery(bool asNoTracking = true)
        {
            var carQuery = _carRepository.GetQuery(asNoTracking); 
            var carList = carQuery.ToList(); 
            var carViewModelList = _mapper.Map<IEnumerable<CarViewModel>>(carList);

            return carViewModelList.AsQueryable(); 
        }

        public async Task Remove(CarViewModel viewModel)
        {
            var car = _mapper.Map<Car>(viewModel);
           await _carRepository.Remove(car);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveRange(IEnumerable<CarViewModel> viewModels)
        {
            var cars = _mapper.Map<IEnumerable<Car>>(viewModels);
           await _carRepository.RemoveRange(cars);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Update(CarViewModel viewModel)
        {
            var car = _mapper.Map<Car>(viewModel); 
           await _carRepository.Update(car);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
