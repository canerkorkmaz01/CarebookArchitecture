using Carebook.ENTITIES.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carebook.BLL.FluentValidation.EntityValidation
{
    public class FeatureValidation : AbstractValidator<Feature>
    {
        public FeatureValidation()
        {
             RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori alanı boş bırakılamaz");          
        }
    }
}
