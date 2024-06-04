using Carebook.ENTITIES.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carebook.ENTITIES.Models
{
    public class Contact:BaseEntity
    {
        public string Address { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
    }
}
