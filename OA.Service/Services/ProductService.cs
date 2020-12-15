using OA.Data;
using OA.Repo.Interfaces;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Services
{
    public class ProductService : BaseService<OA.Data.ProductCatalog>, IProductService
    {
        #region Fields
        private readonly IProductRepository _productRepository;
        #endregion

        #region Constructors
        public ProductService(IProductRepository productRepository)
            : base(productRepository)
        {
            _productRepository = productRepository;

        }
        #endregion

        #region ComplexQueries
        public async Task<IEnumerable<ProductCatalog>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }

        public async Task<ProductCatalog> GetProductById(int productId)
        {
            if (productId > 0)
                return await _productRepository.GetProductById(productId);
            else
                return null;
        }

        #endregion


        #region Methods
        public bool AddProduct(ProductCatalog product)
        {
            if (product != null)
                return _productRepository.AddProduct(product);
            return false;
        }
        public bool UpdateProduct(ProductCatalog product)
        {
            if (product != null)
                return _productRepository.UpdateProduct(product);
            return false;
        }
        public bool DeleteProduct(int productId)
        {
            if (productId > 0)
                return _productRepository.DeleteProduct(productId);
            return false;
        }
        #endregion
    }
}
