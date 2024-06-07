using Carebook.ENTITIES.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carebook.BLL.FluentValidation.EntityValidation
{
    public class ReservationValidaton : AbstractValidator<Reservation>
    {
        public ReservationValidaton()
        {
            RuleFor(x => x.CarId).NotEmpty().WithMessage("Araç Adı Boş Bırakılmaz");
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Adı Soyadı");
            RuleFor(x => x.Telephone).NotEmpty().WithMessage("Telefonu Alanı Boş Bırakılamaz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Adresi Boş Geçilemez");
            RuleFor(x => x.FuelType).NotEmpty().WithMessage("Yakıt Tipi Boş Bırakılamaz");
            RuleFor(x => x.GearType).NotEmpty().WithMessage("Vites Tipi Alanı Boş Bırakılamaz");
        }
    }
}
