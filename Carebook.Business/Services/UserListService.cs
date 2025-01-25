using AutoMapper;
using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Carebook.DataAccess.Interface;

namespace Carebook.Business.Services
{
    public class UserListService : IUserListService
    {
        private readonly IUserListRepository _userListService;
        private readonly IMapper _mapper;  

        public UserListService(IUserListRepository userListService, IMapper mapper)
        {
            _userListService = userListService; 
            _mapper = mapper;   
        }

        public async Task<IEnumerable<UserViewModel>> UserListServices()
        {
            var userlist = await _userListService.UserNameAsync();
            return  _mapper.Map<IEnumerable< UserViewModel>>(userlist);
        }
    }
}
