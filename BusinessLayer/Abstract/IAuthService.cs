using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;

namespace BusinessLayer.Abstract
{
    public interface IAuthService
    {
        IDataResult<Users> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<Users> Login(UserForLoginDto userForLoginDto);
        IDataResult<Users> VendorRegister(VendorForRegisterDto vendorForRegisterDto, string password);
        IDataResult<Users> VendorLogin(VendorForLoginDto vendorForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(Users user);
    }
}
