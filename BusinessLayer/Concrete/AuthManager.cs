using BusinessLayer.Abstract;
using BusinessLayer.BusinessAspects.Autofac;
using BusinessLayer.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Core.Entities;

namespace BusinessLayer.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IVendorService _vendorService;
        private IEmailService _emailService;

        public AuthManager(IUserService userService,IEmailService emailService,ITokenHelper tokenHelper, IVendorService vendorService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _vendorService = vendorService; 
            _emailService= emailService;
        }

        #region Register
        public IDataResult<Users> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new Users
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Contact = userForRegisterDto.Contact,
            };
            //
            //
            string subject = "YokYok'a Hoşgeldiniz !";
            string body = "<div style='background-color: black; color: white; width: 50%; font-size:32px; padding:10px 20px; text-align:center; font-weight:bold '>" + "<p style = 'padding: 10px 20px; font-size: 48px; font-weight: bold;' > YOKYOK </p>" + "<p>" + user.FirstName.ToUpper() + " " + user.LastName.ToUpper() + "</p> " + "<p style= 'padding: 10px 20px; font-size: 24px;'> Bizi tercih ettiğiniz için teşekkür ederiz. </p> <p style= 'padding: 10px 20px; font-size: 24px;'> İyi alışverişler dileriz.</p>" + "</div>" ;
            Users[] users = new Users[] { user };
            _emailService.SendEmail(users,subject,body);
            _userService.Add(user);
            return new SuccessDataResult<Users>(user, Messages.UserRegistered);
        }

        public IDataResult<Users> VendorRegister(VendorForRegisterDto vendorForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new Users
            {
                Email = vendorForRegisterDto.Email,
                FirstName = vendorForRegisterDto.Name,
                LastName = vendorForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Contact = vendorForRegisterDto.Contact,
            };
            _userService.Add(user);
            return new SuccessDataResult<Users>(user, Messages.UserRegistered);
        }

        public IDataResult<Users> CustomerRegister(CustomerForRegisterDto customerForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new Users
            {
                Email = customerForRegisterDto.Email,
                FirstName = customerForRegisterDto.FirstName,
                LastName = customerForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Contact = customerForRegisterDto.Contact,

            };
            _userService.Add(user);
            return new SuccessDataResult<Users>(user, Messages.UserRegistered);
        }

       
        #endregion

        //[SecuredOperation("vendor,admin")]
        public IDataResult<Users> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<Users>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<Users>(Messages.PasswordError);
            }

            return new SuccessDataResult<Users>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(Users user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<Users> VendorLogin(VendorForLoginDto vendorForLoginDto)
        {
            throw new NotImplementedException();
        }

    }
}
