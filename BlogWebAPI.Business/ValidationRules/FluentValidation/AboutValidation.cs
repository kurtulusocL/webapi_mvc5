using BlogWebAPI.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.Business.ValidationRules.FluentValidation
{
    public class AboutValidation : AbstractValidator<About>
    {
        public AboutValidation()
        {
            RuleFor(i => i.Title).NotEmpty().WithMessage("Title can not be empty");
            RuleFor(i => i.Subtitle).NotEmpty().WithMessage("Subtitle can not be empty");
            RuleFor(i => i.Description).NotEmpty().WithMessage("Description can not be empty");
            RuleFor(i => i.Photo).NotEmpty().WithMessage("Photo can not be empty");
        }
    }
}
