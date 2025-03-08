using Carebook.Common.ViewModels;
using FluentValidation;

namespace Carebook.Business.ValidationRules
{
    public class ReservationValidator :AbstractValidator<ReservationViewModel>
    {
        public ReservationValidator()
        {
            RuleFor(x => x.CarId).NotEmpty().WithMessage("{CarId} alanı boş bırakılamaz").WithName("Araç Adı");
            RuleFor(x=>x.NameSurname).NotEmpty().WithMessage("{NameSurname} alanı boş bırakılamaz").WithName("Adı Soyadı").Length(10,100).
                WithMessage("Minimum 20 karekter maksimum 100 kareter girmelisiniz");
            //RuleFor(x=>x.Telephone).NotEmpty().WithMessage("{Telephone} alanı boş bırakılamaz").WithName("Telefonu").Length(10).
            //    WithMessage("Telefon numarası 11 haneli olarak giriniz");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("{Email} alanı boş bırakılamaz").WithName("Email Adresi");
            RuleFor(x => x.RentalDate).NotEmpty().SetValidator(new CustomDateFormatValidator<ReservationViewModel>("dd.MM.yyyy"));
            RuleFor(x => x.PurchaseDate).NotEmpty().SetValidator(new CustomDateFormatValidator<ReservationViewModel>("dd.MM.yyyy"));
            RuleFor(x => x.DeliveryDate).NotEmpty().SetValidator(new CustomDateFormatValidator<ReservationViewModel>("dd.MM.yyyy"));
            RuleFor(x => x.FuelType).NotEmpty().WithMessage("{FuelType} alanı boş bırakılamaz").WithName("Yakıt Tipi");
            RuleFor(x => x.GearType).NotEmpty().WithMessage("{GearType} alanı boş bırakılamaz").WithName("Vites Tipi Soyadı");
        }
    }
}
