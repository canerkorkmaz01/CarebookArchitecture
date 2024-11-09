using Carebook.Common.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carebook.Business.ValidationRules
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().EmailAddress().WithMessage("{PropertyName} alanı boş bırakılamaz!").WithName("E-Posta")
                  .Matches(@"^[a-zA-Z0-9&_.-]+@[a-zA-Z.-]+\.[a-zA-Z0-9]{2,5}$").WithMessage("Lütfen geçerli bir e-posta adresi yazınız!");
    


            RuleFor(x => x.Password).NotEmpty().WithMessage("{PropertyName} alanı boş bırakılamaz!").WithName("Parola");

            RuleFor(x => x.RememberMe);
        }
    }
}
