using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public  class EfOrderedProductDal: EfEntityRepositoryBase<OrderedProduct, dbContext>, IOrdereProductDal
    {


        public List<OrderedProductDto> getAllOrdereProductByVendorId(int vendorId)
        {

            using (dbContext context = new dbContext())
            {
                var res = from orderedProduct in context.OrderedProduct
                          join order in context.Orders
                          on orderedProduct.OrderID equals order.OrderID
                          join c in context.Customer
                          on order.CustomerID equals c.CustomerId
                          join v in context.VendorProduct
                          on orderedProduct.VendorProductID equals v.VendorProductID
                          join p in context.Product
                          on v.ProductID equals p.ProductID
                          where v.VendorID == vendorId && orderedProduct.State == 0
                          select new OrderedProductDto
                          {
                              CustomerId = c.CustomerId,
                              Name = c.FirstName + c.LastName,
                              OrderDate = order.OrderDate,
                              ProductName = p.ProductName,
                              Quantity = v.Quantity,
                              State = orderedProduct.State,
                              OrderID=order.OrderID,
                          };

                        
                        


                          
                return res.ToList();

            }
        }
    }
}
