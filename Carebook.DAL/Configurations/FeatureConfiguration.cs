using Carebook.ENTITIES.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carebook.DAL.Configurations
{
    public class FeatureConfiguration : BaseConfiguration<Feature>
    {
        public virtual void Configure(EntityTypeBuilder<Feature> builder)
        {
            //base.Configure(builder);
            builder
              .HasMany(p => p.Cars)
              .WithMany(p => p.Features);
            //    .LeftNavigation.

            //builder
            //    .HasIndex(p => new { p.Name })
            //    .IsUnique();

            builder
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
