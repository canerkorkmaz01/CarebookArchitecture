using Carebook.ENTITIES.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carebook.DAL.Configurations
{
    public class CarConfiguration : BaseConfiguration<Car>
    {
        public override void Configure(EntityTypeBuilder<Car> builder)
        {
            //base.Configure(builder);
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
