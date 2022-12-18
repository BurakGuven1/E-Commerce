using BusinessLayer.Abstract;
using Entities.Concrete;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController:ControllerBase
    {

        ICartService _cartService;


        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("getbyid/{customerId}")]
        public IActionResult GetById(int customerId)
        {
            var result = _cartService.GetByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Cart cart)
        {
            var result = _cartService.Add(cart);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //iyzico için--> 1- Kullanıcıyı al 2- Sepetteki toplam tutarı hesapla 3-PaymentCard Nesnesi oluştur. 4-Buyer nesnesi oluştur
        // 5-Kargo ve fatura nesnelerini oluştur 6-CartDetails BasketItem listesi olarak hazırla 7- ödeme isteği oluştur
        //8 ödeme yap 9- işlem başarılıysa sipariş fatura oluştur 10-sepeti kapat 11-işlem başarılı sayfasına yönlendir 12-Sandbox paneline bak

    }

}
