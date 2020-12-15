using OA.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface IProductService : IBaseService<OA.Data.ProductCatalog>
    {
        #region ComplexQureies
        Task<IEnumerable<ProductCatalog>> GetAllProducts();
        Task<ProductCatalog> GetProductById(int productId);
        #endregion

        #region Methods
        bool AddProduct(ProductCatalog product);
        bool UpdateProduct(ProductCatalog product);
        bool DeleteProduct(int productId);
        #endregion
    }
}
