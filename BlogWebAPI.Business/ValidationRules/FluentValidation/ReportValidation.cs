using BlogWebAPI.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.Business.ValidationRules.FluentValidation
{
    public class ReportValidation : AbstractValidator<Report>
    {
        public ReportValidation()
        {
            RuleFor(i => i.NameSurname).NotEmpty().WithMessage("Name surname can not be empty");
            RuleFor(i => i.PhoneNumber).NotEmpty().WithMessage("Phone number can not be empty");
            RuleFor(i => i.Subject).NotEmpty().WithMessage("Report subject can not be empty");
            RuleFor(i => i.Text).NotEmpty().WithMessage("Report can not be empty");
            RuleFor(i => i.EmailAddress).EmailAddress().WithMessage("E-Mail Address can not be empty and e-mail address should be valid e-mail.");
        }
    }
}
