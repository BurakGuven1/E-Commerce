using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
     public interface ICartService
    {
        IDataResult<List<Cart>> GetAll();
        IDataResult<Cart> GetByCustomerId(int customerId);
        IResult Add(Cart cart);
    }
}
