using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using BusinessLayer.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
          
        }

        public IResult Add(Product product)
        {
            //iş kodları buraya... eğer ürün öyleyse böyleyse kodları... her şey geçerliyse ekle geçersizse ekleme
            
            ValidationTool.Validate(new ProductValidator(),product);
            
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //if (DateTime.Now.Hour == 12)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime); // ürün listesini döndürüyüroz çünkü frontende lazım.
            //}

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);

        }


        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryID==id)); // SuccessDataResult içinde List of Product var ona parantez içini gönderiyosun
        }

        public IDataResult<List<Product>> GetAllUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductID==productId)); // SuccessDataResult içinde  Product var ona parantez içini gönderiyosun
        }

        public IDataResult<List<OrderBoxDetailDto>> GetOrderBoxDetails(int id)
        {
            return new SuccessDataResult<List<OrderBoxDetailDto>>(_productDal.GetOrderBoxDetails(id));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
