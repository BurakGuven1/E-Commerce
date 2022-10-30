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
        public class CartProductManager : ICartProductService
        {
            ICartProductDal _cartProductDal;

            public CartProductManager(ICartProductDal cartProductDal)
            {
                _cartProductDal = cartProductDal;
            }

            public IResult Add(CartProduct cartProduct)
            {
                _cartProductDal.Add(cartProduct);
                return new SuccessResult(Messages.CartAdded);
            }

            public IDataResult<List<CartProduct>> GetAll()
            {
                return new SuccessDataResult<List<CartProduct>>(_cartProductDal.GetAll());
            }

            public IDataResult<CartProduct> GetByCartId(int CartID)
            {
                return new SuccessDataResult<CartProduct>(_cartProductDal.Get(c => c.CartID == CartID));
            }
        }
}
