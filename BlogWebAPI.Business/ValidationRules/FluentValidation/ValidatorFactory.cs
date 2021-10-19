using BlogWebAPI.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.Business.ValidationRules.FluentValidation
{
    public class ValidatorFactory : ValidatorFactoryBase
    {
        private static Dictionary<Type, IValidator> validators = new Dictionary<Type, IValidator>();

        static ValidatorFactory()
        {
            validators.Add(typeof(IValidator<About>), new AboutValidation());
            validators.Add(typeof(IValidator<Category>), new CategoryValidation());           
            validators.Add(typeof(IValidator<Blog>), new BlogValidation());
            validators.Add(typeof(IValidator<BlogDetail>), new BlogDetailValidation());
            validators.Add(typeof(IValidator<Contact>), new ContactValidation());
            validators.Add(typeof(IValidator<Report>), new ReportValidation());
            validators.Add(typeof(IValidator<SocialMedia>), new SocialMediaValidation());
            validators.Add(typeof(IValidator<Subcategory>), new SubcategoryValidation());
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            IValidator validator;
            if (validators.TryGetValue(validatorType, out validator))
            {
                return validator;
            }
            return validator;
        }
    }
}
