using Carebook.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carebook.DataAccess.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Ignore(p=>p.PicturesToDeleted);

            builder.Ignore(p => p.SelectedFeatures);

            builder.Ignore(p => p.PhotoFile);

            builder.Ignore(p => p.PhotoFiles);
            builder
                .HasIndex(p => new { p.CarName })
                .IsUnique();
            builder
                .HasIndex(p => new { p.Year });
            //.IsUnique();
            builder
                .HasIndex(p => new { p.Safe });
            //.IsUnique();
            builder
                .HasIndex(p => new { p.FuelType });
            //.IsUnique();
            builder
                .HasIndex(p => new { p.GearType });
            //.IsUnique();
            builder
                .HasIndex(p => new { p.Kilometer });
            //.IsUnique();
            builder
                .HasIndex(p => new { p.Armchair });
            //.IsUnique();
            builder
                .HasIndex(p => new { p.SuitCase });
            //.IsUnique();
            builder
                .HasIndex(p => new { p.Licence });
            //.IsUnique();
            builder
              .HasIndex(p => new { p.Plate })
               .IsUnique();

            builder
                .Property(p => p.Photo)
                .HasColumnType("varchar(max)")
                .IsUnicode(false)   
                .IsRequired(false); 

            builder
                .Property(p => p.CarName)
                .IsUnicode(false)
                .HasMaxLength(200)
                .IsRequired();
            builder
               .Property(p => p.Year)
               .IsUnicode(false)
               .HasMaxLength(4)
               .IsRequired();
            builder
               .Property(p => p.Safe)
               .IsUnicode(false)
                .HasMaxLength(200)
               .IsRequired();
            builder
               .Property(p => p.FuelType)
                .IsUnicode(false)
               .HasMaxLength(200)
               .IsRequired();
            builder
               .Property(p => p.GearType)
               .IsUnicode(false)
               .HasMaxLength(200)
               .IsRequired();

            builder
               .Property(p => p.Armchair)
               .IsUnicode(false)
               .HasMaxLength(200)
               .IsRequired();
            builder
               .Property(p => p.SuitCase)
              .IsUnicode(false)
               .HasMaxLength(200)
               .IsRequired();
            builder
               .Property(p => p.Licence)
                .IsUnicode(false)
               .HasMaxLength(200)
               .IsRequired();

            builder
                .Property(p => p.Plate)
                .IsUnicode(false)
                .HasMaxLength(200)
                .IsRequired();

            builder
              .Property(p => p.Kilometer)
              .IsUnicode(false)
              .IsRequired()
              .HasPrecision(18, 0);

            builder
              .HasMany(p => p.CarPictures)
              .WithOne(p => p.Car)
              .HasForeignKey(p => p.CarId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
