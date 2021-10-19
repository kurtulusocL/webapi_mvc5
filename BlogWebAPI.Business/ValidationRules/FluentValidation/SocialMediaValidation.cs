using BlogWebAPI.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.Business.ValidationRules.FluentValidation
{
    public class SocialMediaValidation : AbstractValidator<SocialMedia>
    {
        public SocialMediaValidation()
        {
            RuleFor(i => i.Name).NotEmpty().WithMessage("Name can not be empty.");
            RuleFor(i => i.Url).NotEmpty().WithMessage("Url can not be empty and please type a URL.");
            RuleFor(i => i.Logo).NotEmpty().WithMessage("Logo can not be empty.");
        }
    }
}
