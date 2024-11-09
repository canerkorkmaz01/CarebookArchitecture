using Carebook.Entities;
using FluentValidation;

namespace Carebook.Business.ValidationRules
{
    public class PricingValidator:AbstractValidator<Pricing>
    {
        public PricingValidator()
        {
                RuleFor(x=>x.CarId).NotEmpty().WithName("Araç Adı"); 
        }
    }
}
