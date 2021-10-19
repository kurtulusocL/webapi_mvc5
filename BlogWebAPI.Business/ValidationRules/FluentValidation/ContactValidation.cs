using BlogWebAPI.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.Business.ValidationRules.FluentValidation
{
    public class ContactValidation : AbstractValidator<Contact>
    {
        public ContactValidation()
        {
            RuleFor(i => i.EmailAddress).EmailAddress().WithMessage("E-Mail Address can not be empty and e-mail address should be valid e-mail.");
            RuleFor(i => i.City).NotEmpty().WithMessage("City can not be empty");
            RuleFor(i => i.Country).NotEmpty().WithMessage("Country can not be empty");
        }
    }
}
