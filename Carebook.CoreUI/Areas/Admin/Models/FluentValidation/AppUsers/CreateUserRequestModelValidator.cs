using Carebook.CoreUI.Areas.Admin.Models.AppUsers.RequestModels;
using FluentValidation;

namespace Carebook.CoreUI.Areas.Admin.Models.FluentValidation.AppUsers
{
    public class CreateUserRequestModelValidator : AbstractValidator<CreateUserRequestModel>
    {
        public CreateUserRequestModelValidator()
        {
                RuleFor(x =>x.UserName).NotEmpty().WithMessage("Kullanıcı Adı boş geçilemez");
                RuleFor(x =>x.Email).NotEmpty().WithMessage("Email alanı boş geçilemez").EmailAddress().WithMessage("Lütfen Email Dogru Formatta Giriniz");
        }
    }
}
