using Carebook.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carebook.DataAccess.Configurations
{
    public class CarPictureConfiguration : IEntityTypeConfiguration<CarPicture>
    {
        public void Configure(EntityTypeBuilder<CarPicture> builder)
        {
            builder
                 .Property(p => p.Photo)
                 .IsUnicode(false);
        }
    }
}
