using Carebook.ENTITIES.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carebook.BLL.FluentValidation.EntityValidation
{
    public class CarValidation : AbstractValidator<Car>
    {
        public CarValidation()
        {
            RuleFor(x => x.CarName).NotEmpty().WithMessage("Araç alanı boş bırakılamaz");
            RuleFor(x => x.Year).NotEmpty().WithMessage("Yılı alanı boş bırakılamaz");
            RuleFor(x => x.Safe).NotEmpty().WithMessage("Kasa alanı boş bırakılamaz");
            RuleFor(x => x.FuelType).NotEmpty().WithMessage("Yakıt Tipi alanı boş bırakılamaz");
            RuleFor(x => x.GearType).NotEmpty().WithMessage("Vites Tipi alanı boş bırakılamaz");
            RuleFor(x => x.Kilometer).NotEmpty().WithMessage("Kilometre alanı boş bırakılamaz");
            RuleFor(x => x.Armchair).NotEmpty().WithMessage("Koltuk Sayısı alanı boş bırakılamaz");
            RuleFor(x => x.SuitCase).NotEmpty().WithMessage("Valiz Sayısı alanı boş bırakılamaz");
            RuleFor(x => x.Licence).NotEmpty().WithMessage("Ehliyet alanı boş bırakılamaz");
            RuleFor(x => x.Plate).NotEmpty().WithMessage("Araç plakası alanı boş bırakılamaz");

        }
    }
}
