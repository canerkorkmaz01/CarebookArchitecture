using Carebook.DataAccess.Context;
using Carebook.DataAccess.Interface;
using Carebook.Entities;
using Microsoft.EntityFrameworkCore;


namespace Carebook.DataAccess.Repositories
{
    public class ContactListRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactListRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> ContactList()
        {
            return await _context.Contacts
                .Include(u=>u.User)
                .OrderBy(x=> x.Address).ToListAsync();
        }
    }
}
