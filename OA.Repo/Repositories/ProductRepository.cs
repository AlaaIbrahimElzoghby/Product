using OA.Data;
using OA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OA.Repo.Repositories
{
    public class ProductRepository : BaseRepository<OA.Data.ProductCatalog>, IProductRepository
    {
        #region Fields
        private readonly ApplicationContext _applicationContext;
        #endregion

        #region Constructores
        public ProductRepository(ApplicationContext context) : base(context)
        {
            _applicationContext = context;
        }
        #endregion

        #region ComplexQueries
        public IEnumerable<ProductCatalog> GetAllProducts()
        {
            return _applicationContext.Products;
        }
        #endregion

        #region Methods
        public bool AddProduct(ProductCatalog product)
        {
            try
            {
                _applicationContext.Products.Add(product);
                return SaveChanges();
            }
            catch (Exception e)
            {
                return false;
                // we can log exception here in exception table
            }

        }
        public bool UpdateProduct(ProductCatalog product)
        {
            try
            {
                _applicationContext.Products.Update(product);
                return SaveChanges();
            }
            catch (Exception e)
            {
                return false;
                // we can log exception here in exception table
            }
        }
        public bool DeleteProduct(int productId)
        {
            try
            {
                var data = _applicationContext.Products.Where(p => p.id == productId).FirstOrDefault();
                _applicationContext.Products.Remove(data);
                return SaveChanges();
            }
            catch (Exception e)
            {
                return false;
                // we can log exception here in exception table
            }
        }
        #endregion
    }

}
