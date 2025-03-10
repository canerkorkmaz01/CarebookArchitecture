using Carebook.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Carebook.DataAccess.Context
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            // Veritabanı Context'i ve diğer hizmetleri al
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();

            // Veritabanını kontrol et ve yoksa oluştur
            await context.Database.MigrateAsync();

            // Seed verilerini ekle
            await SeedData(userManager, roleManager, configuration);
        }

        private static async Task SeedData(UserManager<User> userManager, RoleManager<Role> roleManager, IConfiguration configuration)
        {
            var roleNames = configuration.GetSection("Roles")?.Get<string[]>() ?? Array.Empty<string>();
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    var role = new Role
                    {
                        Name = roleName,
                        DisplayName = roleName // DisplayName'i de atanıyor
                    };
                    await roleManager.CreateAsync(role);
                }
            }

            // Admin kullanıcı ekleme kısmı
            var adminUserInfo = configuration.GetSection("DefaultUser");
            var adminUserName = adminUserInfo["Username"] ?? "defaultAdmin";
            var adminEmail = adminUserInfo["Email"] ?? "admin@example.com";
            var adminPassword = adminUserInfo["Password"] ?? "DefaultPassword123";

            if (await userManager.FindByNameAsync(adminUserName) == null)
            {
                var adminUser = new User
                {
                    UserName = adminUserName,
                    Email = adminEmail,
                    Name = "Administrators" // Name sütununa bir değer atanıyor
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Administrators");
                }
            }
        }

    }
}
