using Carebook.Entities;
using FluentValidation;

namespace Carebook.Business.ValidationRules
{
    public class FeatureValidator: AbstractValidator<Feature>
    {
        public FeatureValidator()
        {
              RuleFor(x=>x.Name).NotEmpty().WithMessage("Kategori adı boş bırakılmaz").Length(5,50).
                WithMessage("Kategori alanı 5 ile 50 karekter arasında olmalı");      
        }
    }
}
