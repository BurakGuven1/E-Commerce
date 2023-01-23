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
    public interface IOrderService
    {
        IDataResult<List<Orders>> GetAll();
        IDataResult<Orders> GetAllByCustomerId(int id);
        IDataResult<List<Orders>> GetAllOrderDate(DateTime orderDate);

        //IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Orders> GetById(int OrderID);
        IDataResult<Orders> Add(Orders order);
    }
}
