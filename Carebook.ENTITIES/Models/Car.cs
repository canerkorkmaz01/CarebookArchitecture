using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Carebook.ENTITIES.Enums.CarEnum;
using Microsoft.AspNetCore.Http;
using Carebook.ENTITIES.Enums;
using Carebook.ENTITIES.Infrastructure;

namespace Carebook.ENTITIES.Models
{
    public class Car:BaseEntity
    {
        //[Display(Name = "Araç Adı")]
        //[Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public string CarName { get; set; }

        //[Display(Name = "Yılı")]
        //[Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public int Year { get; set; }

        //[Display(Name = "Kasa")]
        //[Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public Safe Safe { get; set; }

        //[Display(Name = "Yakıt Tipi")]
        //[Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public FuelType FuelType { get; set; }

        //[Display(Name = "Vites Tipi")]
        //[Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public GearType GearType { get; set; }

        //[Display(Name = "Kilometresi")]
        //[Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public decimal Kilometer { get; set; }

        //[Display(Name = "Koltuk Sayısı")]
        //[Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public int Armchair { get; set; }

        //[Display(Name = "Valiz Sayısı")]
        //[Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public int SuitCase { get; set; }

        //[Display(Name = "Ehliyeti")]
        //[Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public Licence Licence { get; set; }

        //[Display(Name = "Araç Plakası")]
        //[Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public string Plate { get; set; }

        [NotMapped]
        public int[] PicturesToDeleted { get; set; }

        public string Photo { get; set; }

        [NotMapped]
        public int[] SelectedFeatures { get; set; }


        [NotMapped]
        [Display(Name = "Foto")]
        public IFormFile PhotoFile { get; set; }

        [NotMapped]
        [Display(Name = "Foto Galeri")]
        public IFormFile[] PhotoFiles { get; set; }

        public virtual ICollection<CarPicture> CarPictures { get; set; } = new HashSet<CarPicture>();
        public virtual ICollection<Feature> Features { get; set; } = new HashSet<Feature>();
        public virtual Reservation Reservations { get; set; }
        public virtual Pricing Pricings { get; set; }
        
    }
}
