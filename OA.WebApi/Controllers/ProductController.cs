using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.Data;
using OA.Service.Interfaces;

namespace OA.WebApi.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        
        [HttpGet]
        public IEnumerable<ProductCatalog> GetAllProducts()
        {
            return _productService.GetAllProducts().ToList(); ;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductCatalog product)
        {
            product.lastUpdated = DateTime.Now;
            if (_productService.AddProduct(product))
                return Ok();
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put([FromBody] ProductCatalog product)
        {
            if(product.id <= 0)
                return BadRequest();
            product.lastUpdated = DateTime.Now;

            if (_productService.UpdateProduct(product))
                return Ok();
            return BadRequest();
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (_productService.DeleteProduct(id))
                return Ok();
            return BadRequest();

        }
    }
}
