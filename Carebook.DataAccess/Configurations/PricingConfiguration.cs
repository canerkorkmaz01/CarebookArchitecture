using Carebook.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Carebook.DataAccess.Configurations
{
    public class PricingConfiguration : IEntityTypeConfiguration<Pricing>
    {
        public void Configure(EntityTypeBuilder<Pricing> builder)
        {
            builder
               .Property(p => p.HourlyRate)
               .IsUnicode(false)
               .IsRequired()
               .HasPrecision(18, 0);
            builder
             .Property(p => p.DailyWages)
             .IsUnicode(false)
             .IsRequired()
             .HasPrecision(18, 0);
            builder
             .Property(p => p.MonthlyFee)
             .IsUnicode(false)
             .IsRequired()
             .HasPrecision(18, 0);
        }
    }
}
