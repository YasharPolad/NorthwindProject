using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
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
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if(result.IsSuccess == false)
            {
                return BadRequest(result.Message);
            }
            
            return Ok(result.Data);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetProductById(id);
            if(result.IsSuccess == false)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var result = _productService.Add(product);
            if(result.IsSuccess == false)
            {
                return BadRequest(result.Message);
            }

            return Ok();
        }

    }
}
