using Carebook.Business.DependencyResolvers.Microsoft;
using Carebook.Business.Interfaces;
using Carebook.Business.Profiles;
using Carebook.Business.Services;
using Carebook.Common.ViewModels;
using Carebook.DataAccess.Context;
using Carebook.DataAccess.Interface;
using Carebook.DataAccess.Repositories;
using Carebook.DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.Configure<MvcOptions>(options =>
{
    options.ModelValidatorProviders.Clear();
});

// Identity yapýlandýrmasý
builder.Services.AddIdentityCore<UserViewModel>()
    .AddRoles<IdentityRole<int>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();



builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie();

builder.Services.AddDependencies(builder.Configuration);

builder.Services.AddScoped<IUserListRepository, UserListRepository>();
builder.Services.AddScoped<IUserListService, UserListService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"))
           .UseLazyLoadingProxies(false));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<ICarService, CarHomeListService>();
builder.Services.AddScoped<ICarHomeRepository, CarHomeRepository>();
builder.Services.AddScoped<ICarFeatureRepository, CarFeatureRepository>();
builder.Services.AddScoped<ICarFeatureService, CarFeatureService>();
builder.Services.AddScoped<ICarPageListRepository, CarPageListRepository>();
builder.Services.AddScoped<ICarPageListService, CarPageListService>();
builder.Services.AddScoped<IService<FeatureViewModel>, FeatureService>();
builder.Services.AddScoped<IFeatureService, FeatureNameService>();
builder.Services.AddScoped<IFeatureRepository, FeatureRepository>();
builder.Services.AddScoped<ICarPictureRepository, CarPictureRepository>();
builder.Services.AddScoped<ICarPictureService, CarPictureAsyncService>();

builder.Services.AddScoped<IService<ReservationViewModel>, ReservationService>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IReservationService, ReservationListService>();

builder.Services.AddScoped<IService<ContactViewModel>, ContactService>();
builder.Services.AddScoped<IContactRepository, ContactListRepository>();
builder.Services.AddScoped<IContactService, ContactListService>();

builder.Services.AddScoped<IService<PricingViewModel>, PricingService>();
builder.Services.AddScoped<ICarDropdownListRepository, CarDropdownListRepository>();
builder.Services.AddScoped<ICarDropdownListService, CarDropdownListService>();
builder.Services.AddScoped<IPricingRepository, PricingRepository>();
builder.Services.AddScoped<IPricingService, PricingCarService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

await DbInitializer.Initialize(app.Services, app.Configuration);


app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();





