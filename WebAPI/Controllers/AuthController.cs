using BusinessLayer.Abstract;
using BusinessLayer.BusinessAspects.Autofac;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        private IVendorService _vendorService;
        private ICustomerService _customerService;
        private IUserService _userService;
        private IUserOperationClaimService _userclaimService;
        public AuthController(IAuthService authService,IUserService userService,IVendorService vendorService, ICustomerService customerService
            , IUserOperationClaimService userclaimService)
        {
            _authService = authService;
            _vendorService = vendorService;
            _customerService = customerService;
            _userService = userService;
            _userclaimService = userclaimService;


        }

        [HttpPost("login")]
        public  ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        //todo: userid ye göre geri dönüş yapılacak

        
        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);

            // customer added
          var resultcustomer= _customerService.Add(new Customer()
            {
                Contact = userForRegisterDto.Contact,
                DOB = userForRegisterDto.DOB,
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Gender = userForRegisterDto.Gender,
                PasswordHash = Encoding.ASCII.GetBytes(userForRegisterDto.Password),
                PasswordSalt = Encoding.ASCII.GetBytes(userForRegisterDto.Password)


            });

            var customer=_customerService.GetCustomerByEmail(userForRegisterDto.Email);
            _userclaimService.Add(customer.Data.CustomerId, 1);
            
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success && resultcustomer.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
       


        [HttpPost("vendorregister")]
        public ActionResult VendorRegister(VendorForRegisterDto vendorForRegisterDto)
        {
            var userExists = _authService.UserExists(vendorForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.VendorRegister(vendorForRegisterDto, vendorForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);

            Vendor vendor = new Vendor();
            vendor.Address = vendorForRegisterDto.Address;
            vendor.Email = vendorForRegisterDto.Email;
            vendor.Name = vendorForRegisterDto.Name;
            vendor.PasswordHash = Encoding.ASCII.GetBytes(vendorForRegisterDto.Password);
            vendor.PasswordSalt = Encoding.ASCII.GetBytes(vendorForRegisterDto.Password);
            vendor.Contact = vendorForRegisterDto.Contact;
            _vendorService.Add(vendor);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("customerregister")]
        public ActionResult CustomerRegister(CustomerForRegisterDto customerForRegisterDto)
        {
            
            var userExists = _authService.UserExists(customerForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }
 
            var registerResult = _authService.CustomerRegister(customerForRegisterDto, customerForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);

            Customer customer = new Customer();

            customer.Email = customerForRegisterDto.Email;
            customer.FirstName = customerForRegisterDto.FirstName;
            customer.LastName = customerForRegisterDto.LastName;

            customer.Gender= customerForRegisterDto.Gender;
            customer.PasswordHash = Encoding.ASCII.GetBytes(customerForRegisterDto.Password);
            customer.PasswordSalt = Encoding.ASCII.GetBytes(customerForRegisterDto.Password);
            customer.Contact = customerForRegisterDto.Contact;
            customer.DOB = customerForRegisterDto.DOB;
            _customerService.Add(customer);

            var customerfetch = _userService.GetByMail(customerForRegisterDto.Email);

            _userclaimService.Add(customerfetch.Id, 1);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyid/{userId}")]
        public IActionResult GetClaims(int userId)
        {
            var user = _userService.GetByUserId(userId);
            var result = _userService.GetClaims(user.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //customer a ekle

    }
}
