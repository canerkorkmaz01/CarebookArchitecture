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
         

            CreateMap<UserViewModel, User>().ReverseMap();
            CreateMap<ContactViewModel, Contact>().ReverseMap();
            CreateMap<Pricing, PricingViewModel>().ReverseMap();
          
            CreateMap<Reservation, ReservationViewModel>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User != null ? new UserViewModel
            {
                Name = src.User.Name
            } : null)).ReverseMap()
            .ForMember(dest => dest.Cars, opt => opt.MapFrom(src => src.Cars != null ? new CarViewModel
            {
                Id = src.Cars.Id,
                CarName = src.Cars.CarName
            } : null)).ReverseMap();

            CreateMap<Car, CarViewModel>(); 
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
