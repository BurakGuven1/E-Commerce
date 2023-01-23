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
    public class OrderedProductController : Controller
    {


        public IOrdereProductService _ordereProductService;

        public OrderedProductController(IOrdereProductService ordereProductService)
        {
            _ordereProductService=ordereProductService;
        }


        [HttpGet("getbyorderedproduct/{vendorId}")]
        public IActionResult GetByCartId(int vendorId)
        {
            var result = _ordereProductService.getAllByVendorId(vendorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(OrderedProduct orderedProduct)
        {
            var result = _ordereProductService.Add(orderedProduct);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("update/{orderId}")]
        public IActionResult GetupdateCartId(int orderId)
        {
            
            var result = _ordereProductService.Update(orderId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }




        //customer a ekle

    }
}
