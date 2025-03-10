using Carebook.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Carebook.DataAccess.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder
              .Property(p => p.NameSurname)
              .IsUnicode(false)
              .HasMaxLength(100)
              .IsRequired();
            builder
               .Property(p => p.Telephone)
               .IsUnicode(false)
               .HasMaxLength(14)
               .IsRequired();
            builder
               .Property(p => p.Email)
               .IsUnicode(false)
               .HasMaxLength(100)
               .IsRequired();
            builder
               .Property(p => p.FuelType)
               .IsUnicode(false)
               .HasMaxLength(50)
               .IsRequired();
            builder
                .Property(p => p.GearType)
                .IsUnicode(false)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
