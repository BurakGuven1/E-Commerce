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
    public interface IOrdereProductService
    {

        IDataResult<List<OrderedProductDto>> getAllByVendorId(int vendorId);
        IResult Add(OrderedProduct order);
        IDataResult<OrderedProduct> Update(int order);


    }
}
