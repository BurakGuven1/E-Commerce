﻿using BusinessLayer.Abstract;
using BusinessLayer.BusinessAspects.Autofac;
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

        public AuthController(IAuthService authService,IVendorService vendorService)
        {
            _authService = authService;
            _vendorService = vendorService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
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

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
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

    }
}
