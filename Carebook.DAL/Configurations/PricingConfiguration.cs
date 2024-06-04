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
    public class PricingConfiguration : BaseConfiguration<Pricing>
    {
        public virtual void Configuration(EntityTypeBuilder<Pricing> builder) 
        {


        }
    }
}
