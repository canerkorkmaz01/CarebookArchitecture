using Carebook.Common.ViewModels;
using FluentValidation;

namespace Carebook.Business.ValidationRules
{
    public class PricingValidator:AbstractValidator<PricingViewModel>
    {
        public PricingValidator()
        {
            RuleFor(x=>x.CarId).NotEmpty().WithName("Araç Adı Seçiniz");
            RuleFor(x => x.HourlyRate).NotEmpty().WithName("Lütfen saatlik ücret miktarını giriniz! ");
            RuleFor(x => x.DailyWages).NotEmpty().WithName("Lütfen günlük ücret miktarını giriniz! ");
            RuleFor(x => x.MonthlyFee).NotEmpty().WithName("Lütfen aylık ücret miktarını giriniz! ");
        }
    }
}
