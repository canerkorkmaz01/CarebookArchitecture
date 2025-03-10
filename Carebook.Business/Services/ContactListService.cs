using AutoMapper;
using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Carebook.DataAccess.Interface;

namespace Carebook.Business.Services
{
    public class ContactListService: IContactService
    {
        private readonly IContactRepository _contact;
        private readonly IMapper _mapper;

        public ContactListService(IContactRepository contact, IMapper mapper)
        {
            _contact = contact;
            _mapper = mapper;
        }

        public async Task<ContactViewModel> ContacGetList()
        {
            var contact= await _contact.ContacGetListt();

            return _mapper.Map<ContactViewModel>(contact);
        }

        public async Task<IEnumerable<ContactViewModel>> ContactList()
        {
            var contect = await _contact.ContactList();
            return _mapper.Map<IEnumerable<ContactViewModel>>(contect);
        }
    }
}
