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
            CreateMap<Feature, FeatureViewModel>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Enabled, opt => opt.MapFrom(src => src.Enabled))
            .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => src.DateCreated))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<FeatureViewModel, Feature>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Enabled, opt => opt.MapFrom(src => src.Enabled))
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => DateTime.Now)) 
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
        }
    }
}
