using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class VendorManager : IVendorService
    {
        IVendorDal _vendorDal;

        public VendorManager(IVendorDal vendorDal)
        {
            _vendorDal = vendorDal;

        }

        public IResult Add(Vendor vendor)
        {
            //iş kodları buraya... eğer ürün öyleyse böyleyse kodları... her şey geçerliyse ekle geçersizse ekleme

            _vendorDal.Add(vendor);

            return new SuccessResult(Messages.ProductAdded);
        }


        public IDataResult<List<Vendor>> GetAll()
        {
            return new SuccessDataResult<List<Vendor>>(_vendorDal.GetAll(), Messages.ProductsListed);

        }
        public IDataResult<Vendor> GetById(int vendorId)
        {
            return new SuccessDataResult<Vendor>(_vendorDal.Get(p => p.VendorID == vendorId)); // SuccessDataResult içinde  Customer var ona parantez içini gönderiyosun
        }
        public IDataResult<Vendor> GetVendorByEmail(string Email)
        {
            return new SuccessDataResult<Vendor>(_vendorDal.Get(p => p.Email == Email));
        }

    }
}
