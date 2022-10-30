using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICartProductService
    {
        IDataResult<List<CartProduct>> GetAll();
        IDataResult<CartProduct> GetByCartId(int CartID);
        IResult Add(CartProduct cartProduct);
    }
}
