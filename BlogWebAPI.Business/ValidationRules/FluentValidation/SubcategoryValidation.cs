using BlogWebAPI.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.Business.ValidationRules.FluentValidation
{
    public class SubcategoryValidation : AbstractValidator<Subcategory>
    {
        public SubcategoryValidation()
        {
            RuleFor(i => i.CategoryId).NotEmpty().WithMessage("CategoryID name can not be empty.");
            RuleFor(i => i.Name).NotEmpty().WithMessage("Subcategory name can not be empty.");
        }
    }
}
