using AutoMapper;
using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Carebook.DataAccess.Interface;
using Carebook.Entities;
using System.Linq.Expressions;

namespace Carebook.Business.Services
{
    public class PricingService : IService<PricingViewModel>
    {
        private readonly IRepository<Pricing> _pricingRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PricingService(IRepository<Pricing> pricingRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _pricingRepository = pricingRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(PricingViewModel viewModel)
        {
            var pricing = _mapper.Map<Pricing>(viewModel);
            await _pricingRepository.AddAsync(pricing);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<PricingViewModel> viewModel)
        {
            var pricing = _mapper.Map<IEnumerable<Pricing>>(viewModel);
            await _pricingRepository.AddRangeAsync(pricing);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> CountAsync(Expression<Func<PricingViewModel, bool>> predicate = null)
        {
            Expression<Func<Pricing, bool>> pricingPredicate = _mapper.Map<Expression<Func<PricingViewModel, bool>>, Expression<Func<Pricing, bool>>>(predicate);
            return await _pricingRepository.CountAsync(pricingPredicate);
        }

        public async Task<IEnumerable<PricingViewModel>> FindAsync(Expression<Func<PricingViewModel, bool>> predicate, bool asNoTracking = true)
        {
            Expression<Func<Pricing, bool>> carPredicate = _mapper.Map<Expression<Func<PricingViewModel, bool>>, Expression<Func<Pricing, bool>>>(predicate);
            var pricing = await _pricingRepository.FindAsync(carPredicate, asNoTracking);
            return _mapper.Map<IEnumerable<PricingViewModel>>(pricing);
        }

        public async Task<IEnumerable<PricingViewModel>> GetAllAsync(bool asNoTracking = true)
        {
            var pricing = await _pricingRepository.GetAllAsync(asNoTracking);
             return  _mapper.Map<IEnumerable<PricingViewModel>>(pricing);
        }

        public async Task<PricingViewModel> GetByIdAsync(int id, bool asNoTracking = true)
        {
            var pricing = await _pricingRepository.GetByIdAsync(id,asNoTracking);
            return _mapper.Map<PricingViewModel>(pricing);
        }

        public async Task<IEnumerable<PricingViewModel>> GetPagedResponseAsync(int pageNumber, int pageSize, bool asNoTracking = true)
        {
            var pricing = await _pricingRepository.GetPagedResponseAsync(pageNumber, pageSize, asNoTracking);
            return _mapper.Map<IEnumerable<PricingViewModel>>(pricing);
        }

        public  IQueryable<PricingViewModel> GetQuery(bool asNoTracking = true)
        {
            var pricing = _pricingRepository.GetQuery(asNoTracking);   
            var pricingList= pricing.ToList();  
            var pricingModelView= _mapper.Map<IEnumerable<PricingViewModel>>(pricing);  
            return pricingModelView.AsQueryable();  
        }

        public async Task Remove(PricingViewModel viewModel)
        {
            var pricingviewmodel = _mapper.Map<Pricing>(viewModel);
            await _pricingRepository.Remove(pricingviewmodel);
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task RemoveRange(IEnumerable<PricingViewModel> viewModel)
        {
            var pricingviewmodel = _mapper.Map<IEnumerable<Pricing>>(viewModel);
            await _pricingRepository.RemoveRange(pricingviewmodel); 
            await _unitOfWork.SaveChangesAsync(); 
        }

        public async Task Update(PricingViewModel viewModel)
        {
            var pricingviewmodel = _mapper.Map<Pricing>(viewModel);
            await _pricingRepository.Update(pricingviewmodel);
            await _unitOfWork.SaveChangesAsync();   
        }

        
    }
}
