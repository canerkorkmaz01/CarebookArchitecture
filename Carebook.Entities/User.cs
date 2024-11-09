using Carebook.Common.Enums;
using Microsoft.AspNetCore.Identity;

namespace Carebook.Entities
{
    public class User : IdentityUser<int>
    {
 
        public string Name { get; set; }

        public bool Enabled { get; set; } = true;

        public Genders Gender { get; set; }

        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
        public virtual ICollection<Feature> CarFeatures { get; set; } = new HashSet<Feature>();
        public virtual ICollection<CarPicture> CarPictures { get; set; } = new HashSet<CarPicture>();
        public virtual ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();
        public virtual ICollection<Pricing> Pricings { get; set; } = new HashSet<Pricing>();
        public virtual ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();
    }
}
