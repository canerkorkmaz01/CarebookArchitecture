using Carebook.CoreUI.Areas.Admin.Models.AppRoles.RequestModels;
using FluentValidation;

namespace Carebook.CoreUI.Areas.Admin.Models.FluentValidation.AppRoles
{
    public class CreateRoleRequestModelValidator : AbstractValidator<CreateRoleRequestModel>
    {
        public CreateRoleRequestModelValidator()
        {
            RuleFor(x => x.RoleName).NotEmpty().WithMessage("Role Adı boş geçilemez");
        }
    }
}
