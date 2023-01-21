using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserOperationClaimManager:IUserOperationClaimService
    {
        IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;

        }

        public IResult Add(int userId, int operationClaimId)
        {
            UserOperationClaim userOperationClaim= new UserOperationClaim();
            userOperationClaim.UserId=userId;
            userOperationClaim.OperationClaimId=operationClaimId;

            _userOperationClaimDal.Add(userOperationClaim);

            return new SuccessResult(Messages.CustomerRegistered);
        }
    }
}
