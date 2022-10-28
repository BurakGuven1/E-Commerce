using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product> // dtolar için de yapabiliriz bunu.
    {
        public ProductValidator()
        {
            //customer kontrolü de burada gibi gerçekleşecek. Managerda validation context oluşturup customeri doğrula !! // .with message ile özel mesaj verebiliriz
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            //RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p=>p.CategoryID==1);  categorye göre özel kısıtlama

        }
    }
}
