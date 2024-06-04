using Carebook.ENTITIES.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carebook.ENTITIES.Models
{
    public class CarPicture:SortableBaseEntity
    {
        public int CarId { get; set; }

        public string? Photo { get; set; }

        public virtual Car? Car { get; set; }
    }
}
