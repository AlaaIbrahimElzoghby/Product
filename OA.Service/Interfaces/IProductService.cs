using OA.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Interfaces
{
    public interface IProductService : IBaseService<OA.Data.ProductCatalog>
    {
        #region ComplexQureies
        IEnumerable<ProductCatalog> GetAllProducts();
        ProductCatalog GetProductById(int productId);
        #endregion

        #region Methods
        bool AddProduct(ProductCatalog product);
        bool UpdateProduct(ProductCatalog product);
        bool DeleteProduct(int productId);
        #endregion
    }
}
