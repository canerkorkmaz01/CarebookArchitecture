using Carebook.ENTITIES.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Carebook.ENTITIES.Enums.CarEnum;

namespace Carebook.ENTITIES.Models
{
    public class Reservation:BaseEntity
    {
        //[Display(Name = "Araç Adı")]
        //[Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public int CarId { get; set; }

        //[Display(Name = "Adı Soyadı")]
        //[Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public string NameSurname { get; set; }

        //[Display(Name = "Telefonu")]
        //[Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public string Telephone { get; set; }

        //[Display(Name = "Email Adresi")]
        //[Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public string Email { get; set; }

        //[Display(Name = "Kiralama Tarihi")]
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RentalDate { get; set; }

        //[Display(Name = "Alış Tarihi")]
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; }

        //[Display(Name = "Teslim Tarihi")]
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DeliveryDate { get; set; }


        //[Display(Name = "Yakıt Tipi")]
        //[Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public FuelType FuelType { get; set; }

        //[Display(Name = "Vites Tipi")]
        //[Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public GearType GearType { get; set; }
        public virtual Car Cars { get; set; }
    }
}
