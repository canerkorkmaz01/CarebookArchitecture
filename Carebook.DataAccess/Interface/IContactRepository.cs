using Carebook.Entities;

namespace Carebook.DataAccess.Interface
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> ContactList();

        Task<Contact> ContacGetListt();
    }
}
