using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrdersDal _orderDal;
        public OrderManager(IOrdersDal orderDal)
        {
            _orderDal = orderDal;

        }

        public IDataResult<Orders> Add(Orders orders)
        {
            orders.OrderDate = DateTime.Now;
            //iş kodları buraya... eğer ürün öyleyse böyleyse kodları... her şey geçerliyse ekle geçersizse ekleme
            var result=_orderDal.getAddandgetId(orders);

            return new SuccessDataResult<Orders>(result);
        }
        public IDataResult<List<Orders>> GetAll()
        {
            //if (DateTime.Now.Hour == 12)
            //{
            //    return new ErrorDataResult<List<Orders>>(Messages.MaintenanceTime); // ürün listesini döndürüyüroz çünkü frontende lazım.
            //}

            return new SuccessDataResult<List<Orders>>(_orderDal.GetAll(), Messages.ProductsListed);

        }

        public IDataResult<Orders> GetAllByCustomerId(int id)
        {
            return new SuccessDataResult<Orders>(_orderDal.Get((order)=>order.CustomerID==id)); // SuccessDataResult içinde List of Product var ona parantez içini gönderiyosun.
        }

        public IDataResult<List<Orders>> GetAllOrderDate(DateTime orderDate)
        {
            return new SuccessDataResult<List<Orders>>(_orderDal.GetAll(o => o.OrderDate == orderDate));
        }

        public IDataResult<List<Orders>> GetAllOrderDate()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Orders> GetById(int orderId)
        {
            return new SuccessDataResult<Orders>(_orderDal.Get(o => o.OrderID == orderId)); // SuccessDataResult içinde  Product var ona parantez içini gönderiyosun
        }

    }
}
