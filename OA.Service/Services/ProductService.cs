using OA.Repo.Interfaces;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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

        #endregion


        #region Methods
        
        #endregion
    }
}
