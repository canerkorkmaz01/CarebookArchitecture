using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Carebook.DataAccess.Interface;
using PagedList;

namespace Carebook.Business.Services
{
    public class CarPageListService : ICarPageListService
    {
        private readonly ICarPageListRepository _carPageListRepository;

        public CarPageListService(ICarPageListRepository carPageListRepository)
        {
            _carPageListRepository = carPageListRepository;
        }

        public async Task<IPagedList<CarViewModel>> GetPagedCarsAsync(int pageNumber, int pageSize)
        {
            // Burada sorguyu Service katmanına taşıyoruz
            return await _carPageListRepository.GetPagedCarsAsync(pageNumber, pageSize);
        }
    }
}
