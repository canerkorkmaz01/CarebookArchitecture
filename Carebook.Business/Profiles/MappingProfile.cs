using AutoMapper;
using Carebook.Common.ViewModels;
using Carebook.Entities;


namespace Carebook.Business.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarViewModel>().ReverseMap();
            CreateMap<User, RegisterViewModel>().ReverseMap();
           
        }
    }
}
