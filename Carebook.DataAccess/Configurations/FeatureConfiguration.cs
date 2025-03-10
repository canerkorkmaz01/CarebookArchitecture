using Carebook.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Carebook.DataAccess.Configurations
{
    public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
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
