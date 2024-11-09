using Carebook.Common.Enums;

namespace Carebook.Common.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }
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

        public int[]? PicturesToDeleted { get; set; }

        public string? Photo { get; set; }

        public int[]? SelectedFeatures { get; set; }

        public string? PhotoBase64 { get; set; }

        public byte[]? PhotoFiles { get; set; }


        public virtual ICollection<CarPictureViewModel> CarPictures { get; set; } = new HashSet<CarPictureViewModel>();
        public virtual ICollection<FeatureViewModel> Features { get; set; } = new HashSet<FeatureViewModel>();
        public virtual ReservationViewModel Reservations { get; set; }
        public PricingViewModel Pricings { get; set; }
    }
}
