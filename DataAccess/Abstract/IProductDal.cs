using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepo<Product>
    {
        List<ProductDetailDto> GetProductDetails();
        List<OrderBoxDetailDto> GetOrderBoxDetails(int id);
        List<VendorProductDetailDto> GetVendorProductDetails(int id);
        List<VendorProductDetailDtoWithId> GetVendorProductDetailsByVendorId(int vendorId);
        List<VendorProductDetailDto> GetVendorProductDetailsByCategoryId(int categoryId);
        Product getAddandgetId(Product product);
    }
}
