using Carebook.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Carebook.DataAccess.Context
{
    public class AppDbContext :IdentityDbContext<User,Role,int>
    {
        public AppDbContext(DbContextOptions options):base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());   
            base.OnModelCreating(builder);
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarPicture> CarPictures { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Pricing> Pricings { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
    }
}
