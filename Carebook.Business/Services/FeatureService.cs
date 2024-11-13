using AutoMapper;
using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Carebook.DataAccess.Interface;
using Carebook.Entities;
using System.Linq.Expressions;

namespace Carebook.Business.Services
{
    public class FeatureService : IService<Feature>
    {

        private readonly IRepository<Feature> _featureRepository;
        private readonly IMapper _mapper;

        public FeatureService(IRepository<Feature> featureRepository, IMapper mapper)
        {
            _featureRepository = featureRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(Feature entity)
        {
            await _featureRepository.AddAsync(entity); 
        }

        public async Task AddRangeAsync(IEnumerable<Feature> entities)
        {
           await _featureRepository.AddRangeAsync(entities);    
        }

        public async Task<int> CountAsync(Expression<Func<Feature, bool>> predicate = null)
        {
            return await _featureRepository.CountAsync(predicate);
        }

        public async Task<IEnumerable<Feature>> FindAsync(Expression<Func<Feature, bool>> predicate, bool asNoTracking = true)
        {
            return await _featureRepository.FindAsync(predicate, asNoTracking);
        }

        public async Task<IEnumerable<Feature>> GetAllAsync(bool asNoTracking = true)
        {
            var feature = await _featureRepository.GetAllAsync(asNoTracking);
            return (IEnumerable<Feature>)_mapper.Map<IEnumerable<FeatureViewModel>>(feature);
        }

        public async Task<Feature> GetByIdAsync(int id, bool asNoTracking = true)
        {
            return await _featureRepository.GetByIdAsync(id, asNoTracking);
        }

        public async Task<IEnumerable<Feature>> GetPagedResponseAsync(int pageNumber, int pageSize, bool asNoTracking = true)
        {
            return await _featureRepository.GetPagedResponseAsync(pageNumber, pageSize, asNoTracking);
        }

        public IQueryable<Feature> GetQuery(bool asNoTracking = true)
        {
           return _featureRepository.GetQuery(asNoTracking);
        }

        public void Remove(Feature entity)
        {
            _featureRepository.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Feature> entities)
        {
           _featureRepository.RemoveRange(entities);
        }

        public void Update(Feature entity)
        {
           _featureRepository.Update(entity);
        }
    }
}
