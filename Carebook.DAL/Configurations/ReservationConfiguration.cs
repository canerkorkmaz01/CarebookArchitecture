using Carebook.ENTITIES.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carebook.DAL.Configurations
{
    public class ReservationConfiguration:BaseConfiguration<Reservation>
    {
        public virtual void Configuration(EntityTypeBuilder<Pricing> builder)
        {


        }
    }
}
