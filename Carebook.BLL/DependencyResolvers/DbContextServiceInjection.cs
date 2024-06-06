using Carebook.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carebook.BLL.DependencyResolvers
{
    public static class DbContextServiceInjection
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services)
        {
            ServiceProvider provider = services.BuildServiceProvider(); 
            IConfiguration configuration = provider.GetService<IConfiguration>();
            services.AddDbContextPool<AppDbContex>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionStrings")).UseLazyLoadingProxies());
            return services;
        }
        
    }
}
