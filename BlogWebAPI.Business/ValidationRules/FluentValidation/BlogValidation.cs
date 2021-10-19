using BlogWebAPI.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.Business.ValidationRules.FluentValidation
{
    public class BlogValidation : AbstractValidator<Blog>
    {
        public BlogValidation()
        {
            RuleFor(i => i.Title).NotEmpty().WithMessage("Blog title can not be empty");
            RuleFor(i => i.Subtitle).NotEmpty().WithMessage("Blog subtitle can not be empty");
            RuleFor(i => i.Detail).NotEmpty().WithMessage("Blog detail can not be empty");
            RuleFor(i => i.Photo).NotEmpty().WithMessage("Blog photo can not be empty");
            RuleFor(i => i.CategoryId).NotEmpty().WithMessage("Blog category can not be empty");
            RuleFor(i => i.SubcategoryId).NotEmpty().WithMessage("Blog subcategory can not be empty");
        }
    }
}
