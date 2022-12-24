using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class CategoryValidator: AbstractValidator<Category>
    {
        public CategoryValidator() 
        {
            RuleFor(p => p.CategoryName).NotEmpty();
        }
    }
}
