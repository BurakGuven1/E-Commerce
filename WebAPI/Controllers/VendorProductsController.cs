using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorProductsController : ControllerBase
    {
        IProductService _productService;

        public VendorProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getbyvendorproductid/{id}")]
        public IActionResult GetVendorProductDetails(int id)
        {
            var result = _productService.GetVendorProductDetails(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbycategoryid/{id}")]
        public IActionResult GetAllByCategoryId(int id)
        {
            var result = _productService.GetVendorProductDetailsByCategoryId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
