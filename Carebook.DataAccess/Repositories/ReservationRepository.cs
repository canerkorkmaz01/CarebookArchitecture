using Carebook.DataAccess.Context;
using Carebook.DataAccess.Interface;
using Carebook.Entities;
using Microsoft.EntityFrameworkCore;

namespace Carebook.DataAccess.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly AppDbContext _context;
        public ReservationRepository(AppDbContext context)
        {
            _context = context;   
        }

        public async Task<IEnumerable<Car>> GetReservationAsync()
        {
            return await _context.Cars.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetReservationNameAsync()
        {
            return await _context.Reservations
                .Include(p=>p.Cars)
                .Include(u=>u.User)
                .OrderBy(x=>x.NameSurname).ToListAsync();
        }

   
    }
}
