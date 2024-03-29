﻿using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
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
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
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

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getproductsbycategoryid/{id}")]

        public IActionResult GetAllByCategoryId(int id)
        {
            var res = _productService.GetAllByCategoryId(id);
            if (res.Success)
            {
                return Ok(res);

            }
            return BadRequest(res);
        }


        [HttpPost("add")]
        public IActionResult Add(VendorProductDetailDto product)
        {
            var result = _productService.DtoAdd(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("updateVenProduct/{id}/{stock}")]
        public IActionResult Update(int id,int stock)
        {
            
            var result =_productService.Update(id, stock);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("deleteVenProduct/{id}/{productId}")]
        public IActionResult Delete(int id,int productId)
        {

            var result = _productService.Deleete(id, productId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
