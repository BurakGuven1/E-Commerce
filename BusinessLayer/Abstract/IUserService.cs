using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(Users user);
        void Add(Users user);
        Users GetByMail(string email);
        IDataResult<Users> GetByUserId(int userId);
    }
}
