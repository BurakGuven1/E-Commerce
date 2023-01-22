using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, dbContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (dbContext context = new dbContext())
            {
                var result = from p in context.Product
                             join c in context.Category
                             on p.CategoryID equals c.CategoryID
                             select new ProductDetailDto { ProductID = p.ProductID, ProductName = p.ProductName, CategoryName = c.CategoryName, UnitsInStock = p.UnitsInStock };
                return result.ToList();
            }
        }

        public List<OrderBoxDetailDto> GetOrderBoxDetails(int id)
        {
            using(dbContext context = new dbContext())
            {
                var res = from c in context.Customer
                          join ca in context.Cart
                          on c.CustomerId equals ca.CustomerID
                          join cp in context.CartProduct
                          on ca.CartID equals cp.CartID
                          join vp in context.VendorProduct
                          on cp.VendorProductID equals vp.VendorProductID
                          join p in context.Product
                          on vp.ProductID equals p.ProductID
                          where c.CustomerId == id
                          select new OrderBoxDetailDto {CustomerID=c.CustomerId, 
                              CartID= ca.CartID,
                              Quantity = cp.Quantity,
                              VendorProductID = vp.VendorProductID,
                              ProductID = p.ProductID,
                              ProductName = p.ProductName,
                              UnitPrice = p.UnitPrice};
                return res.ToList();

            }
        }

        public List<VendorProductDetailDto> GetVendorProductDetails(int id)
        {
            using (dbContext context = new dbContext())
            {
                var result = from vp in context.VendorProduct
                             join p in context.Product
                             on vp.ProductID equals p.ProductID
                             where vp.ProductID == id
                            
                             select new VendorProductDetailDto
                             {
                                 VendorID = vp.VendorID,
                                 Price = vp.Price,
                                 Description = vp.Description,
                                 ProductName = p.ProductName,
                                 CategoryID = p.CategoryID,
                                 ProductPhoto = p.ProductPhoto

                             };
                return result.ToList();
            }
        }
        public List<VendorProductDetailDto> GetVendorProductDetailsByCategoryId(int categoryId)
        {
            using (dbContext context = new dbContext())
            {
                var result = from vp in context.VendorProduct
                             join p in context.Product
                             on vp.ProductID equals p.ProductID
                             where p.CategoryID==categoryId
                             select new VendorProductDetailDto
                             {
                                
                                 VendorID=vp.VendorID,
                                 Price=vp.Price,
                                 Description=vp.Description,
                                 ProductName=p.ProductName,
                                 CategoryID=p.CategoryID,
                                 ProductPhoto=p.ProductPhoto
                             };
                return result.ToList();
            }
        }
        public List<VendorProductDetailDtoWithId> GetVendorProductDetailsByVendorId(int vendorId)
        {
            using (dbContext context = new dbContext())
            {
                var result = from vp in context.VendorProduct
                             join p in context.Product
                             on vp.ProductID equals p.ProductID
                             join c in context.Category
                             on p.CategoryID equals c.CategoryID
                             where vp.VendorID==vendorId 
                             select new VendorProductDetailDtoWithId
                             {

                                 VendorID = vp.VendorID,
                                 Price = vp.Price,
                                 Description = vp.Description,
                                 ProductName = p.ProductName,
                                 CategoryName=c.CategoryName,
                                 ProductPhoto = p.ProductPhoto,

                                 UnitsInStock=p.UnitsInStock,
                                 VendorProductID=vp.VendorProductID,
                                 ProductID=p.ProductID
                             };
                return result.ToList();
            }
        }

        public Product getAddandgetId(Product product)
        {
            Product returnproduct = product;

            using (dbContext context = new dbContext())
            {
                var addedEntity = context.Entry(product); //ref i yakala
                addedEntity.State = EntityState.Added; // bu aslında eklenebilecek bi nesne
                context.SaveChanges(); //ekle 
                returnproduct = addedEntity.Entity;
            }
            return returnproduct;
        }
    }
}
