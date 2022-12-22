using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
        public class CustomerManager:ICustomerService
        {
            ICustomerDal _customerDal;

            public CustomerManager(ICustomerDal customerDal)
            {
                _customerDal = customerDal;

            }

            public IResult Add(Customer customer)
            {
                //iş kodları buraya... eğer ürün öyleyse böyleyse kodları... her şey geçerliyse ekle geçersizse ekleme
                _customerDal.Add(customer);

                return new SuccessResult(Messages.CustomerRegistered);
            }

        public IDataResult<List<Customer>> GetAll()
            {
                if (DateTime.Now.Hour == 12)
                {
                    return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime); // ürün listesini döndürüyüroz çünkü frontende lazım.
                }

                return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.ProductsListed);

            }


            public IDataResult<List<Customer>> GetAllByCustomerId(int id)
            {
                return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(p => p.CustomerId == id)); // SuccessDataResult içinde List of Customer var ona parantez içini gönderiyosun
            }

            public IDataResult<List<Customer>> GetAllByDOB(DateTime DOB)
            {
                return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(p => p.DOB == DOB));
            }

            public IDataResult<List<Customer>> GetAllFirstName(string FirstName)
            {
                return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(p => p.FirstName == FirstName));
            }

            public IDataResult<Customer> GetById(int customerId)
            {
                return new SuccessDataResult<Customer>(_customerDal.Get(p => p.CustomerId == customerId)); // SuccessDataResult içinde  Customer var ona parantez içini gönderiyosun
            }

            public IDataResult<Customer> GetCustomerByEmail(string Email)
            {
                return new SuccessDataResult<Customer>(_customerDal.Get(p => p.Email == Email));
            }
    }
}
