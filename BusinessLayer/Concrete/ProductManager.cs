using BusinessLayer.Abstract;
using BusinessLayer.BusinessAspects.Autofac;
using BusinessLayer.Constants;
using BusinessLayer.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
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
        IVendorProductDal _vendorProductDal;
        ICategoryService _categoryService;
        IVendorService _vendorService;
        



        public ProductManager(IProductDal productDal, ICategoryService categoryService, IVendorProductDal vendorProductDal,
            IVendorService vendorService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
            _vendorProductDal = vendorProductDal;
            _vendorService = vendorService;
            
        }

        //[SecuredOperation("product.add,admin")]  
        //[ValidationAspect(typeof(ProductValidator))]   //Add metodunu doğrula ProductValidatordaki kurallara göre 
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryID),
                 CheckIfProductNameExists(product.ProductName), CheckIfCategoryLimitExceded());
            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);

        }

        public IDataResult<List<Product>> GetAll()
        {
            //if (DateTime.Now.Hour == 12)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime); // ürün listesini döndürüyüroz çünkü frontende lazım.
            //}

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);

        }


        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryID == id)); // SuccessDataResult içinde List of Product var ona parantez içini gönderiyosun
        }

        public IDataResult<List<Product>> GetAllUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductID == productId)); // SuccessDataResult içinde  Product var ona parantez içini gönderiyosun
        }

        public IDataResult<List<OrderBoxDetailDto>> GetOrderBoxDetails(int id)
        {
            return new SuccessDataResult<List<OrderBoxDetailDto>>(_productDal.GetOrderBoxDetails(id));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        public IDataResult<List<VendorProductDetailDto>> GetVendorProductDetails(int id)
        {
            return new SuccessDataResult<List<VendorProductDetailDto>>(_productDal.GetVendorProductDetails(id));
        }

        public IDataResult<List<VendorProductDetailDto>> GetVendorProductDetailsByCategoryId(int categoryId)

        {
            return new SuccessDataResult<List<VendorProductDetailDto>>(_productDal.GetVendorProductDetailsByCategoryId(categoryId));
        }

        
        public IResult Update(Product product)
        {
             _productDal.Update(product);

            return new SuccessDataResult<Product>();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int CategoryID)
        {
            //Select count(*) from products where categoryId= ... 'dir alttaki kod.
            var result = _productDal.GetAll(p => p.CategoryID == CategoryID).Count;
            if (result >= 21)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 25)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }

        public IDataResult<Product>  DtoAdd(VendorProductDetailDto model)
        {
          


            var product = _productDal.getAddandgetId(new Product
            {
                CategoryID = model.CategoryID,
                ProductName = model.ProductName,
                ProductPhoto = model.ProductPhoto,
                UnitPrice = 0,
                State = true,
                UnitsInStock = model.UnitsInStock
            });

           

             _vendorProductDal.Add(new VendorProduct
            {
                
                Description = model.Description,
                Price = model.Price,
                ProductID = product.ProductID,
                Quantity = 0,
                VendorID = model.VendorID,
            });
            
            /*
            try
            {
                using (dbContext context = new dbContext())
                {
                    //Product Ekleme İşlemi
                    Product product = context.Product.Add(new Product
                    {
                        CategoryID = model.CategoryID,
                        ProductName = model.ProductName,
                        ProductPhoto = model.ProductPhoto,
                        UnitPrice = 0,
                        State = true,
                        UnitsInStock = model.UnitsInStock
                    }).Entity;


                    //Vendor Product Ekleme

                    VendorProduct vendorProduct = context.VendorProduct.Add(new VendorProduct
                    {
                        CategoryID = model.CategoryID,
                        Description = model.Description,
                        Price = model.Price,
                        ProductID = product.ProductID,
                        Quantity = 0,
                        VendorID = model.VendorID,
                    }).Entity;

                    result.Success = true;
                    result.Message = "Başarıyla eklendi.";
                }
            }
            catch (Exception)
            {
                result.Success = false;
            }
            */

            return new SuccessDataResult<Product>(product);
        }

        public Product getAddedId(Product product)
        {
           
            return _productDal.getAddandgetId(product);
        }

        public IDataResult<List<VendorProductDetailDtoWithId>> GetVendorProductDetailsByVendorId(int vendorId)
        {

            return new SuccessDataResult<List<VendorProductDetailDtoWithId>>(_productDal.GetVendorProductDetailsByVendorId(vendorId));
        }

        public IDataResult<Product> Update(int id,int stock)
        {
           //var vendorProduct = _vendorProductDal.Get((product) => product.VendorProductID == id);

            var product = _productDal.Get((product) => product.ProductID == id);

            product.UnitsInStock= stock; 
            _productDal.Update(product);
           
            return new SuccessDataResult<Product>(product);
        }

        public IDataResult<Product> Deleete(int id,int productId)
        {
            var vendorproduct=_vendorProductDal.Get((vendorproduct) => vendorproduct.VendorProductID== id);
            _vendorProductDal.Delete(vendorproduct);
            var product = _productDal.Get((product)=>product.ProductID==productId);
            _productDal.Delete(product);
        
            return new SuccessDataResult<Product>(product);
        }
    }
}
