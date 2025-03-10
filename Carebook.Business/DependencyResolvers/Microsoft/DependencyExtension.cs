using Carebook.Business.Interfaces;
using Carebook.Business.Services;
using Carebook.Business.ValidationRules;
using Carebook.Common.ViewModels;
using Carebook.DataAccess.Context;
using Carebook.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Carebook.Business.Sys;
namespace Carebook.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection service,IConfiguration configuration)
        {
            service.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            service.AddValidatorsFromAssemblyContaining<CarValidator>();
            service.AddValidatorsFromAssemblyContaining<CarPictureValidator>();
            service.AddValidatorsFromAssemblyContaining<ContactValidator>();
            service.AddValidatorsFromAssemblyContaining<FeatureValidator>();
            service.AddValidatorsFromAssemblyContaining<PricingValidator>();
            service.AddValidatorsFromAssemblyContaining<ReservationValidator>();
            service.AddValidatorsFromAssemblyContaining<UserValidator>();
            service.AddValidatorsFromAssemblyContaining<RegisterViewModelValidator>();
            service.AddValidatorsFromAssemblyContaining<LoginViewModel>();
            service.AddScoped<IService<CarViewModel>, CarService>();
            service.AddScoped<IUserService, UserService>();

            service.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireDigit = configuration.GetValue<bool>("Application:Password:RequireDigit");
                options.Password.RequiredLength = configuration.GetValue<int>("Application:Password:RequiredLength");
                options.Password.RequireLowercase = configuration.GetValue<bool>("Application:Password:RequireLowercase");
                options.Password.RequireUppercase = configuration.GetValue<bool>("Application:Password:RequireUppercase");
                options.Password.RequireNonAlphanumeric = configuration.GetValue<bool>("Application:Password:RequireNonAlphanumeric");
                options.Lockout.MaxFailedAccessAttempts = configuration.GetValue<int>("Application:Lockout:MaxFailedAccessAttempts");
                options.Lockout.DefaultLockoutTimeSpan = configuration.GetValue<TimeSpan>("Application:Lockout:DefaultLockoutTimeSpan");
            })
          .AddEntityFrameworkStores<AppDbContext>()
          .AddErrorDescriber<MvcStoreIdentityErrorDescriber>()
          .AddDefaultTokenProviders();
            
        }
    }
}
