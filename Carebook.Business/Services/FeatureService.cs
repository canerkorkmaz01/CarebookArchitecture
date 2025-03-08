using AutoMapper;
using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Carebook.DataAccess.Interface;
using Carebook.Entities;
using System.Linq.Expressions;

namespace Carebook.Business.Services
{
    public class FeatureService : IService<FeatureViewModel>
    {

        private readonly IRepository<Feature> _featureRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public FeatureService(IRepository<Feature> featureRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _featureRepository = featureRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(FeatureViewModel entity)
        {
            var feature = _mapper.Map<Feature>(entity);
            var featureRepository =  _unitOfWork.Repository<Feature>();
            await featureRepository.AddAsync(feature);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<FeatureViewModel> entities)
        {
            var feature = _mapper.Map<IEnumerable<Feature>>(entities);
           await _featureRepository.AddRangeAsync(feature);    
        }

        public async Task<int> CountAsync(Expression<Func<FeatureViewModel, bool>> predicate = null)
        {
            Expression<Func<Feature, bool>> feature =_mapper.Map<Expression<Func<FeatureViewModel, bool>>, Expression<Func<Feature, bool>>>(predicate);
            return await _featureRepository.CountAsync(feature);
        }

        public async Task<IEnumerable<FeatureViewModel>> FindAsync(Expression<Func<FeatureViewModel, bool>> predicate, bool asNoTracking = true)
        {
            Expression<Func<Feature,bool>> feature =_mapper.Map<Expression<Func<FeatureViewModel,bool>>, Expression<Func<Feature, bool>>>(predicate);
           var features= await _featureRepository.FindAsync(feature, asNoTracking);
            return _mapper.Map<IEnumerable<FeatureViewModel>>(features);
        }

        public async Task<IEnumerable<FeatureViewModel>> GetAllAsync(bool asNoTracking = true)
        {
            var feature = await _featureRepository.GetAllAsync(asNoTracking);
            return (IEnumerable<FeatureViewModel>)_mapper.Map<IEnumerable<FeatureViewModel>>(feature);
        }

        public async Task<FeatureViewModel> GetByIdAsync(int id, bool asNoTracking = true)
        {
            var features = await _featureRepository.GetByIdAsync(id, asNoTracking);
            return _mapper.Map<FeatureViewModel>(features);
        }

        public async Task<IEnumerable<FeatureViewModel>> GetPagedResponseAsync(int pageNumber, int pageSize, bool asNoTracking = true)
        {
            var features = await _featureRepository.GetPagedResponseAsync(pageNumber, pageSize, asNoTracking);
            return  _mapper.Map<IEnumerable<FeatureViewModel>>(features);  
        }

        public IQueryable<FeatureViewModel> GetQuery(bool asNoTracking = true)
        {
            var features = _featureRepository.GetQuery(asNoTracking);
            return _mapper.Map< IQueryable<FeatureViewModel>>(features);
        }

        public async Task Remove(FeatureViewModel entity)
        {
            var feature = _mapper.Map<Feature>(entity);
            var featurerepository = _unitOfWork.Repository<Feature>();
            await _featureRepository.Remove(feature);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveRange(IEnumerable<FeatureViewModel> entities)
        {
            var features = _mapper.Map<IEnumerable<Feature>>(entities);
            var featurerepository = _unitOfWork.Repository<Feature>();
            await _featureRepository.RemoveRange(features);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Update(FeatureViewModel entity)
        {
            var features = _mapper.Map<Feature>(entity);
            var featureRepository = _unitOfWork.Repository<Feature>();
            await _featureRepository.Update(features);
            await _unitOfWork.SaveChangesAsync();
        }


      
    }
}
