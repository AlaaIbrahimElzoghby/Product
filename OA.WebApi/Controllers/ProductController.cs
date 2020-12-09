using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ExcelDataReader;
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
        public IActionResult Delete(int productId)
        {
            if (_productService.DeleteProduct(productId))
                return Ok();
            return BadRequest();

        }

        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            if (file.Length > 0)
            {
                Stream stream = file.OpenReadStream();

                IExcelDataReader reader = null;

                if (file.FileName.EndsWith(".xls"))
                {
                    reader = ExcelReaderFactory.CreateBinaryReader(stream);
                }
                else if (file.FileName.EndsWith(".xlsx"))
                {
                    reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                }

                DataSet excelRecords = reader.AsDataSet();
                reader.Close();

                var finalRecords = excelRecords.Tables[0];
                for (int i = 0; i < finalRecords.Rows.Count; i++)
                {
                    ProductCatalog product = new ProductCatalog();
                    product.name = finalRecords.Rows[i][0].ToString();
                    product.price = Convert.ToDecimal(finalRecords.Rows[i][1].ToString());
                    product.lastUpdated = DateTime.Now;

                    _productService.AddProduct(product);
                }

            }

            return Ok();
        }
    }
}
