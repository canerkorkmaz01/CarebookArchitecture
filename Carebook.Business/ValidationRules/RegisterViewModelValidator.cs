using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using FluentValidation;

namespace Carebook.Business.ValidationRules
{
    public class RegisterViewModelValidator:AbstractValidator<RegisterViewModel>
    {
        private readonly IUserService _userService;
        public RegisterViewModelValidator(IUserService userService)
        {
            _userService = userService;


            RuleFor(x=> x.Email).NotEmpty().WithMessage("E-posta adresi gereklidir.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi girin.")
                .Must(BeUniqueEmail).WithMessage("Bu e-posta adresi zaten kayıtlı.")
                  .WithMessage("Bu e-posta adresi zaten kayıtlı.")
                .Matches(@"^[a-zA-Z0-9&_.-]+@[a-zA-Z.-]+\.[a-zA-Z0-9]{2,5}$").WithMessage("Lütfen geçerli bir e-posta adresi yazınız!");

            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} alanı boş bırakılamaz!")
            .WithName("Ad Soyad");
            RuleFor(x => x.Password).NotEmpty().WithName("Parola").WithMessage("{PropertyName}  alanı boş bırakılamaz!");
            RuleFor(x => x.PasswordConfirm).NotEmpty().WithMessage("{PropertyName} alanı boş bırakılamaz!").WithName("Parola Tekrar").Equal(x => x.Password)
            .WithMessage("Şifre ve Şifre Onayı alanı aynı olmalıdır.");
           
        }
        private bool BeUniqueEmail(string email)
        {
            var user = _userService.GetUserByEmail(email);  
            return user == null; 
        }

    }
}
