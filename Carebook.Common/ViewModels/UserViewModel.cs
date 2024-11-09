using Carebook.Common.Enums;

namespace Carebook.Common.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }

        public bool Enabled { get; set; } = true;

        public Genders Gender { get; set; }

        public virtual ICollection<CarViewModel> Cars { get; set; } = new HashSet<CarViewModel>();
        public virtual ICollection<FeatureViewModel> CarFeatures { get; set; } = new HashSet<FeatureViewModel>();
        public virtual ICollection<CarPictureViewModel> CarPictures { get; set; } = new HashSet<CarPictureViewModel>();
        public virtual ICollection<ReservationViewModel> Reservations { get; set; } = new HashSet<ReservationViewModel>();
        public virtual ICollection<PricingViewModel> Pricings { get; set; } = new HashSet<PricingViewModel>();
        public virtual ICollection<ContactViewModel> Contacts { get; set; } = new HashSet<ContactViewModel>();

    }
}