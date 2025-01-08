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

        public async Task<List<Reservation>> GetReservationNameAsync()
        {
            return await _context.Reservations.OrderBy(x=>x.NameSurname).ToListAsync();
        }
    }
}
