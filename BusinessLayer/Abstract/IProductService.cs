using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetAllUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<List<VendorProductDetailDto>> GetVendorProductDetails(int id);
        IDataResult<List<OrderBoxDetailDto>> GetOrderBoxDetails(int id);
        IDataResult<Product> GetById(int productId);
        IDataResult<List<VendorProductDetailDto>> GetVendorProductDetailsByCategoryId(int categoryId);

        IResult Add(Product product);
        IResult Update(Product product);
    }
}
