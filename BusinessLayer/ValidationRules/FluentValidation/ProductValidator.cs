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
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün ismi boş geçilemez !");
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitsInStock).NotEmpty().WithMessage("Ürünün stok adetini belirtiniz !");
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitsInStock).NotEmpty()
            RuleFor(p => p.UnitPrice).GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır!");
            RuleFor(p => p.ProductPhoto).NotEmpty().WithMessage("Fotoğraf yükleyiniz !");


            /*
             RuleFor(customer => customer.Password)
         .NotEmpty().WithMessage("Parola alanı boş geçilemez!")
         .Must(IsPasswordValid).WithMessage("Parolanız en az sekiz karakter, en az bir harf ve bir sayı içermelidir!");

     }

     private bool IsPasswordValid(string arg)
     {
         Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
         return regex.IsMatch(arg);
     }
             */
        }
    }
}
