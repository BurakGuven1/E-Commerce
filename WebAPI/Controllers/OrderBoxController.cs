using BusinessLayer.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderBoxController : ControllerBase
    {
        IProductService _productService;

        public OrderBoxController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getorderdtobycustomerid/{id:int}")]
        public IActionResult GetOrderBoxDetails(int id)
        {
            var result = _productService.GetOrderBoxDetails(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);



        }

    }
}
