using BusinessLayer.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class OrderedProductManager : IOrdereProductService
    {
        public IOrdereProductDal _ordereProductDal;
        public OrderedProductManager(IOrdereProductDal ordereProductDal)
        {
            _ordereProductDal=ordereProductDal;
        }

        

        public IResult Add(OrderedProduct order)
        {
            _ordereProductDal.Add(order);

            return new SuccessResult();
        }

        public IDataResult<List<OrderedProductDto>> getAllByVendorId(int vendorId)
        {


            return new SuccessDataResult<List<OrderedProductDto>>(_ordereProductDal.getAllOrdereProductByVendorId(vendorId));
        }

        public IDataResult<OrderedProduct> Update(int order)
        {

            var orderd = _ordereProductDal.Get((orde) => orde.OrderID == order);
            orderd.State = 1;
            _ordereProductDal.Update(orderd);

            return new SuccessDataResult<OrderedProduct>(orderd);

        }
    }
}
