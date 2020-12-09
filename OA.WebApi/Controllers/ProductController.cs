using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.Data;
using OA.Service.Interfaces;
using OA.WebApi.Helpers;
using OfficeOpenXml;

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
        [Route("Product/GetAllProducts")]
        public IEnumerable<ProductCatalog> GetAllProducts()
        {
            return _productService.GetAllProducts().ToList();
        }

        [HttpGet]
        [Route("Product/GetProductById/{productId}")]
        public ProductCatalog GetProductById(int productId) 
        {
            return _productService.GetProductById(productId);
        }

        [HttpPost]
        [Route("Product/Post")]
        public IActionResult Post([FromBody] ProductCatalog product)
        {
            // Converting from base64 representation to image
            if(product.photoName != null)
            {
                String onlyBase64Text = product.photoName.Substring(23);
                string savedImgName = Images.Instance.Base64ToImage(onlyBase64Text);
                product.photoName = savedImgName;
            }

            product.lastUpdated = DateTime.Now;
            if (_productService.AddProduct(product))
                return Ok();
            return BadRequest();
        }

        [HttpPut]
        [Route("Product/Put")]
        public IActionResult Put([FromBody] ProductCatalog product)
        {
            if(product.id <= 0)
                return BadRequest();

            // Converting from base64 representation to image
            if (product.photoName != null)
            {
                String onlyBase64Text = product.photoName.Substring(23);
                string savedImgName = Images.Instance.Base64ToImage(onlyBase64Text);
                product.photoName = savedImgName;
            }

            product.lastUpdated = DateTime.Now;

            if (_productService.UpdateProduct(product))
                return Ok();
            return BadRequest();
        }


        [HttpDelete]
        [Route("Product/Delete/{productId}")]
        public IActionResult Delete(int productId)
        {
            if (_productService.DeleteProduct(productId))
                return Ok();
            return BadRequest();

        }

        [HttpPost]
        [Route("Product/ImportExcelFile")]
        public IActionResult ImportExcelFile()
        {
            var formFile = Request.Form.Files[0];
            if (formFile.Length > 0)
            {
                var list = new List<ProductCatalog>();
                if (formFile == null || formFile.Length <= 0)
                {
                    return BadRequest();
                }

                if (!Path.GetExtension(formFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    return BadRequest();
                }
                using (var stream = new MemoryStream())
                {
                    formFile.CopyToAsync(stream);

                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        var rowCount = worksheet.Dimension.Rows;

                        for (int row = 2; row <= rowCount; row++)
                        {
                            list.Add(new ProductCatalog
                            {
                                name = worksheet.Cells[row, 1].Value.ToString().Trim(),
                                price = int.Parse(worksheet.Cells[row, 2].Value.ToString().Trim()),
                                lastUpdated = DateTime.Now
                        });

                        }
                    }
                }

                foreach (var product in list)
                {
                    _productService.AddProduct(product);
                }

            }

            return Ok();
        }
    }
}
