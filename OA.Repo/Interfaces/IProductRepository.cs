using OA.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Interfaces
{
    public interface IProductRepository : IBaseRepository<OA.Data.ProductCatalog>
    {
        #region ComplexQueries
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
