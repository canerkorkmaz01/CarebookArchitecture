using AutoMapper;
using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Carebook.DataAccess.Interface;
using Carebook.Entities;
using System.Linq.Expressions;

namespace Carebook.Business.Services
{
    public class ContactService : IService<ContactViewModel>
    {
        private readonly IRepository<Contact> _contactRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IRepository<Contact> contactRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(ContactViewModel viewModel)
        {

            var reservation = _mapper.Map<Contact>(viewModel);
            await _contactRepository.AddAsync(reservation);
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task AddRangeAsync(IEnumerable<ContactViewModel> viewModel)
        {
            var reservation = _mapper.Map<IEnumerable<Contact>>(viewModel);
            await _contactRepository.AddRangeAsync(reservation);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> CountAsync(Expression<Func<ContactViewModel, bool>> predicate = null)
        {
            Expression<Func<Contact, bool>> contactPredicate = _mapper.Map<Expression<Func<ContactViewModel, bool>>, Expression<Func<Contact, bool>>>(predicate);
            return await _contactRepository.CountAsync(contactPredicate);
        }

        public async Task<IEnumerable<ContactViewModel>> FindAsync(Expression<Func<ContactViewModel, bool>> predicate, bool asNoTracking = true)
        {
            Expression<Func<Contact, bool>> carPredicate = _mapper.Map<Expression<Func<ContactViewModel, bool>>, Expression<Func<Contact, bool>>>(predicate);
            var contact = await _contactRepository.FindAsync(carPredicate, asNoTracking);
            return _mapper.Map<IEnumerable<ContactViewModel>>(contact);
        }

        public async Task<IEnumerable<ContactViewModel>> GetAllAsync(bool asNoTracking = true)
        {
            var reservation = await _contactRepository.GetAllAsync(asNoTracking);
            return _mapper.Map<IEnumerable<ContactViewModel>>(reservation);
        }

        public async Task<ContactViewModel> GetByIdAsync(int id, bool asNoTracking = true)
        {
            var reservation = await _contactRepository.GetByIdAsync(id, asNoTracking);
            return _mapper.Map<ContactViewModel>(reservation);
        }
 
        public async Task<IEnumerable<ContactViewModel>> GetPagedResponseAsync(int pageNumber, int pageSize, bool asNoTracking = true)
        {
            var reservation = await _contactRepository.GetPagedResponseAsync(pageNumber, pageSize, asNoTracking);
            return _mapper.Map<IEnumerable<ContactViewModel>>(reservation);
        }

        public  IQueryable<ContactViewModel> GetQuery(bool asNoTracking = true)
        {
            var contact  = _contactRepository.GetQuery(asNoTracking);
            var contactList = contact.ToList();
            var contactModelView = _mapper.Map<IEnumerable<ContactViewModel>>(contact);
            return contactModelView.AsQueryable();
        }

        public async Task Remove(ContactViewModel viewModel)
        {
            var contactiewmodel = _mapper.Map<Contact>(viewModel);
            await _contactRepository.Remove(contactiewmodel);
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task RemoveRange(IEnumerable<ContactViewModel> viewModel)
        {
            var contactiewmodel = _mapper.Map<IEnumerable<Contact>>(viewModel);
            await _contactRepository.RemoveRange(contactiewmodel);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Update(ContactViewModel viewModel)
        {
            var contactviewmodel = _mapper.Map<Contact>(viewModel);
            await _contactRepository.Update(contactviewmodel);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
