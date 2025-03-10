using Carebook.Common.Enums;
using Carebook.Entities.Infrastructure;

namespace Carebook.Entities
{
    public class Reservation: BaseEntity
    {
        public int CarId { get; set; }
        public string NameSurname { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public DateTime RentalDate { get; set; }   
        public DateTime PurchaseDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public FuelType FuelType { get; set; }
        public GearType GearType { get; set; }
        public virtual Car Cars { get; set; }
    }
}
