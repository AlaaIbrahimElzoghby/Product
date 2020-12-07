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
            _productService.AddProduct(product);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductCatalog product)
        {
            product.id = id;
            _productService.UpdateProduct(product);
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return Ok();

        }
    }
}
