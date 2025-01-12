using AutoMapper;
using Carebook.Common.ViewModels;
using Carebook.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Carebook.Business.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {



             CreateMap<Pricing, PricingViewModel>().ReverseMap();

            CreateMap<Car, CarViewModel>(); // Eğer başka bir ViewModel varsa

            CreateMap<UserViewModel, User>().ReverseMap();
 
            CreateMap<Car, SelectListItem>()
           .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id.ToString()))
           .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.CarName));


            CreateMap<Car, CarViewModel>()
                .ForMember(dest => dest.PicturesToDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.SelectedFeatures, opt => opt.Ignore())
                .ForMember(dest => dest.PhotoFile, opt => opt.Ignore())
                .ForMember(dest => dest.PhotoFiles, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore());

            CreateMap<CarViewModel, Car>()
                .ForMember(dest => dest.CarPictures, opt => opt.Ignore())
                .ForMember(dest => dest.Features, opt => opt.Ignore())
                .ForMember(dest => dest.Reservations, opt => opt.Ignore())
                .ForMember(dest => dest.Pricings, opt => opt.Ignore());


            CreateMap<CarPictureViewModel, CarPicture>().ReverseMap();
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
