using Carebook.Entities;
using FluentValidation;

namespace Carebook.Business.ValidationRules
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
                RuleFor(x=>x.CarName).NotEmpty().WithMessage("{CarName} alanı boş bırakılamaz").WithName("Araç Adı")
                .Length(200).WithMessage("Girilen metin uzunluğu 200 karakter arasında olmalıdır.");

                RuleFor(x => x.Year).NotEmpty().WithMessage("{Year} boş bırakılamaz").WithName("Yılı")
            .Must(value => value >= 1900 && value <= 3000).WithMessage("Lütfen 4 haneli bir sayı giriniz.");

                RuleFor(x => x.Safe).NotEmpty().WithMessage("{Safe} boş bırakılamaz").WithName("Kasa");
                RuleFor(x => x.FuelType).NotEmpty().WithMessage("{FuelType} boş bırakılamaz").WithName("Yakıt Tipi");
                RuleFor(x => x.GearType).NotEmpty().WithMessage("{GearType} boş bırakılamaz").WithName("Vites Tipi");
                RuleFor(x => x.Kilometer).NotEmpty().WithMessage("{Kilometer} boş bırakılamaz").WithName("Kilometresi");
                RuleFor(x => x.Armchair).NotEmpty().WithMessage("{Armchair} sayısı boş bırakılamaz").WithName("Koltuk Sayısı");
                RuleFor(x => x.SuitCase).NotEmpty().WithMessage("{SuitCase} boş bırakılamaz").WithName("Valiz Sayısı");
                RuleFor(x => x.Licence).NotEmpty().WithMessage("{Licence} boş bırakılamaz").WithName("Ehliyeti");
                RuleFor(x => x.Plate).NotEmpty().WithMessage("{Plate} boş bırakılamaz").WithName("Araç Plakası");
               
        }
    }
}
