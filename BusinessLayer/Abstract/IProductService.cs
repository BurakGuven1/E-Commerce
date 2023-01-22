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
        IDataResult<List<OrderBoxDetailDto>> GetOrderBoxDetails(int id);
        IDataResult<Product> GetById(int productId);
        IDataResult<List<VendorProductDetailDto>> GetVendorProductDetailsByCategoryId(int categoryId);
        IDataResult<List<VendorProductDetailDtoWithId>> GetVendorProductDetailsByVendorId(int vendorId);
        IResult Add(Product product);
        IResult Update(Product product);
        IDataResult<Product> DtoAdd(VendorProductDetailDto model);
        IDataResult<Product> Update(int id,int stock);
        IDataResult<Product> Deleete(int id,int productId);
        Product getAddedId(Product product);

    }
}
