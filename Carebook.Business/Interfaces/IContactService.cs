using Carebook.Common.ViewModels;


namespace Carebook.Business.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ContactViewModel>> ContactList();

        Task<ContactViewModel> ContacGetList();
    }
}
