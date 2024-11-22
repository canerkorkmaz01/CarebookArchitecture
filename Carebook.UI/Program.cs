using Carebook.Business.DependencyResolvers.Microsoft;
using Carebook.Business.Interfaces;
using Carebook.Business.Profiles;
using Carebook.Business.Services;
using Carebook.Common.ViewModels;
using Carebook.DataAccess.Context;
using Carebook.DataAccess.Interface;
using Carebook.DataAccess.Repositories;
using Carebook.DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<MvcOptions>(options =>
{
    options.ModelValidatorProviders.Clear(); 
});
builder.Services.AddDependencies(builder.Configuration);


builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICarFeatureRepository, CarFeatureRepository>();
builder.Services.AddScoped<ICarFeatureService, CarFeatureService>();
builder.Services.AddScoped<ICarPageListRepository, CarPageListRepository>();
builder.Services.AddScoped<ICarPageListService, CarPageListService>();
builder.Services.AddScoped<IService<FeatureViewModel>, FeatureService>();
builder.Services.AddScoped<IFeatureService, FeatureNameService>();
builder.Services.AddScoped<IFeatureRepository, FeatureRepository>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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

//app.MapAreaControllerRoute(
//    name: "user",
//    areaName: "User",
//    pattern: "User/{controller=Account}/{action=Login}/{id?}");

app.Run();
