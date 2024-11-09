using Carebook.Common.Enums;

using Carebook.Entities.Infrastructure;

namespace Carebook.Entities
{
    public class Car:BaseEntity
    {
        
        public string? CarName { get; set; }

        public int Year { get; set; }

        public Safe Safe { get; set; }
       
        public FuelType FuelType { get; set; }

        public GearType GearType { get; set; }
       
        public decimal Kilometer { get; set; }
        
        public int Armchair { get; set; }

        public int SuitCase { get; set; }

        public Licence Licence { get; set; }

        public string? Plate { get; set; }

        //[NotMapped]
        public int[]? PicturesToDeleted { get; set; }

        public string? Photo { get; set; }

        public int[]? SelectedFeatures { get; set; }

        //[Display(Name = "Foto")]
        public string? PhotoBase64 { get; set; }

        public byte[]? PhotoFiles { get; set; }

        public virtual ICollection<CarPicture> CarPictures { get; set; } = new HashSet<CarPicture>();
        public virtual ICollection<Feature> Features { get; set; } = new HashSet<Feature>();
        public virtual Reservation? Reservations { get; set; }
        public virtual Pricing? Pricings { get; set; }
    }
}
