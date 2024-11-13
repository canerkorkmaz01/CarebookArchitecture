using AutoMapper;
using Carebook.Common.ViewModels;
using Carebook.DataAccess.Context;
using Carebook.DataAccess.Interface;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace Carebook.DataAccess.Repositories
{
    public class CarPageListRepository : ICarPageListRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CarPageListRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IPagedList<CarViewModel>> GetPagedCarsAsync(int pageNumber, int pageSize)
        {
            var carsQuery = _context.Cars
                .OrderBy(c => c.CarName);

            var cars = await carsQuery.ToListAsync();
            var carViewModels = _mapper.Map<List<CarViewModel>>(cars);

            return carViewModels.ToPagedList(pageNumber, pageSize);
        }

    }
}
