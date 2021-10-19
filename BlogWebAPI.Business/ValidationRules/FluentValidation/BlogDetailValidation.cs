using BlogWebAPI.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.Business.ValidationRules.FluentValidation
{
    public class BlogDetailValidation : AbstractValidator<BlogDetail>
    {
        public BlogDetailValidation()
        {
            RuleFor(i => i.Subdetail).NotEmpty().WithMessage("Subdetail can not be empty");
            RuleFor(i => i.Text).NotEmpty().WithMessage("Text can not be empty");
        }
    }
}
