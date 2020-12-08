using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.Data;
using OA.Service.Interfaces;
using OA.WebApi.Helpers;

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
            return _productService.GetAllProducts().ToList();
        }

        [HttpGet]
        public ProductCatalog GetProductById(int productId) 
        {
            return _productService.GetProductById(productId);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductCatalog product)
        {
            // Converting from base64 representation to image
            if(product.photoName != null)
            {
                string uniqueImgName = Images.Instance.Base64ToImage(product.photoName);
                product.photoName = uniqueImgName;
            }

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

            // Converting from base64 representation to image
            if (product.photoName != null)
            {
                string uniqueImgName = Images.Instance.Base64ToImage(product.photoName);
                if (uniqueImgName != null)
                    product.photoName = uniqueImgName;
            }

            product.lastUpdated = DateTime.Now;

            if (_productService.UpdateProduct(product))
                return Ok();
            return BadRequest();
        }


        [HttpDelete]
        public IActionResult Delete(int productId)
        {
            if (_productService.DeleteProduct(productId))
                return Ok();
            return BadRequest();

        }
    }
}
