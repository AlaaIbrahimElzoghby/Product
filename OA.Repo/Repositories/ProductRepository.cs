using OA.Repo.Interfaces;
using System;
using System.Collections.Generic;
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
            _context = context;
        }
        #endregion

        #region ComplexQueries
        

        #endregion

        #region Methods
        #endregion
    }

}
