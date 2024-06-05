using Carebook.CoreUI.ViewModels.AppUsers.RequestModels;
using FluentValidation;
using System.Data;

namespace Carebook.CoreUI.FluentValidation.FluentValidation
{
    public class RegisterSignInSharedValidator<T> :AbstractValidator<T> where T : IRegisterSignlnSpec
    {
        public RegisterSignInSharedValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Boş geçilemez").MinimumLength(3).WithMessage("Parola minumum 3 Karekter Olmalı");
        }
    }
}
