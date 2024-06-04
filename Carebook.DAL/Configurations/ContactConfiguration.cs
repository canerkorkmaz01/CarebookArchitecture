using Carebook.ENTITIES.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carebook.DAL.Configurations
{
    public class ContactConfiguration:BaseConfiguration<Contact>
    {
        public virtual void Configure(EntityTypeBuilder<Contact> builder)
        {
            base.Configure(builder);
        }

    }
}
