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
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<Customer>> GetAllByDOB(DateTime DOB);
        IDataResult<Customer> GetCustomerByEmail(string Email);
        IDataResult<List<Customer>> GetAllFirstName(string FirstName);
        IDataResult<Customer> GetById(int CustomerId);
        IResult Add(Customer customer);
    }
}
