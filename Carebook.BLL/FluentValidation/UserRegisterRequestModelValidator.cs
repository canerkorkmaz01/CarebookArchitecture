using Carebook.CoreUI.ViewModels.AppUsers.RequestModels;
using FluentValidation;

namespace Carebook.BLL.FluentValidation
{
    public class UserRegisterRequestModelValidator : RegisterSignInSharedValidator<UserRegisterRequestModel>
    {
        public UserRegisterRequestModelValidator()
        {
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Parolalar Uyuşmuyor").NotEmpty().WithMessage("Şifre tekrar alanı gereklidir");
            RuleFor(x => x.Email).EmailAddress().NotEmpty().When(x => x.UserName == null).WithMessage("Email formatında giriş yapınız");
        }
    }
}
