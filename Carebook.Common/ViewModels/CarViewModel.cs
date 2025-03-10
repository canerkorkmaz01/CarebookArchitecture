using Carebook.Common.Enums;
using Carebook.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Carebook.Common.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string CarName { get; set; }

        public int Year { get; set; }

        public Safe Safe { get; set; }

        public FuelType FuelType { get; set; }

        public GearType GearType { get; set; }

        public decimal Kilometer { get; set; }

        public int Armchair { get; set; }

        public int SuitCase { get; set; }

        public Licence Licence { get; set; }

        public string Plate { get; set; }

        public int[]? PicturesToDeleted { get; set; }

        public string Photo { get; set; }

        public int[] SelectedFeatures { get; set; }

        public IFormFile PhotoFile { get; set; }

        public IFormFile[] PhotoFiles { get; set; }

        public virtual bool Enabled { get; set; }

        public virtual int UserId { get; set; }

        public virtual DateTime DateCreated { get; set; }

        public virtual User? User { get; set; }


        public virtual ICollection<CarPictureViewModel> CarPictures { get; set; } = new HashSet<CarPictureViewModel>();
        public virtual ICollection<FeatureViewModel> Features { get; set; } = new HashSet<FeatureViewModel>();
        public virtual ReservationViewModel Reservations { get; set; }
        public virtual PricingViewModel Pricings { get; set; }
    }
}
