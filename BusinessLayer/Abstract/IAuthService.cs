using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace BusinessLayer.Abstract
{
    public interface IAuthService
    {
        IDataResult<Customer> Register(); // parantez içine dto oluştur yaz
    }
}
