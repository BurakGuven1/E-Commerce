using BusinessLayer.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartProductsController : ControllerBase
    {
        ICartProductService _cartProductService;

        public CartProductsController(ICartProductService cartProductService)
        {
            _cartProductService = cartProductService;
        }

        [HttpGet("getbycartid/{cartId}")]
        public IActionResult GetByCartId(int CartID)
        {
            var result = _cartProductService.GetByCartId(CartID);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(CartProduct cartProduct)
        {
            var result = _cartProductService.Add(cartProduct);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
