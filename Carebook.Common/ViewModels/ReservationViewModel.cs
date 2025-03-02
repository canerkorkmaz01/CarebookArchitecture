using Carebook.Common.Enums;
using Carebook.Entities;
using System;

namespace Carebook.Common.ViewModels
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string NameSurname { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public FuelType FuelType { get; set; }
        public GearType GearType { get; set; }
        public virtual bool Enabled { get; set; }
        public virtual int UserId { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual UserViewModel? User { get; set; }
        public virtual CarViewModel Cars { get; set; }
    }
}
