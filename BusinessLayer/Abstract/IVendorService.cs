using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IVendorService
    {
        IDataResult<List<Vendor>> GetAll();
        IDataResult<Vendor> GetById(int VendorID);
        IResult Add(Vendor vendor);
        IDataResult<Vendor> GetVendorByEmail(string Email);
    }
}
