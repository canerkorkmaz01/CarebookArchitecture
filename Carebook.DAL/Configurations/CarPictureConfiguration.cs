using Carebook.ENTITIES.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carebook.DAL.Configurations
{
    public class CarPictureConfiguration :BaseConfiguration<CarPicture>
    {
        public override void Configure(EntityTypeBuilder<CarPicture> builder)
        {
            //base.Configure(builder);
            builder
                 .Property(p => p.Photo)
                 .IsUnicode(false);
        }
    }
}