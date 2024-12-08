using AutoMapper.Features;
using Carebook.DataAccess.Context;
using Carebook.DataAccess.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Carebook.DataAccess.Repositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly AppDbContext _context;
        public CarFeatureRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<SelectListItem>> GetCarFeaturesAsync()
        {
            return await _context.Features
            .OrderBy(f => f.Name)
            .Select(f => new SelectListItem
            {
                Value = f.Id.ToString(),
                Text = f.Name
            })
            .ToListAsync();
        }

        public async Task<List<SelectListItem>> GetEditCarFeaturesAsync()
        {
            var features = await _context.Features.ToListAsync();

            // LINQ sorgusunu bellekte çalıştırıyoruz
            return features
                .OrderBy(f => f.Name)
                .Select(f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text = f.Name,
                    Selected = features.Any(p => p.Id == f.Id) // Bu kısım bellekte çalışacak
                })
                .ToList();
        }


        public async Task<List<int>> GetFeatureIdsByCarIdAsync(int carId)
        {
            var car = await _context.Cars
                .Include(c => c.Features).AsNoTracking() 
                .FirstOrDefaultAsync(c => c.Id == carId);

            if (car == null)
                throw new Exception("Car not found");

            return car.Features.Select(f => f.Id).ToList();
        }


        public async Task GetFeatureById(int id)
        {
          await _context.Features.FindAsync(id);
        }
    }
}
