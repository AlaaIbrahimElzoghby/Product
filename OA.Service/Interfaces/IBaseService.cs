using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OA.Service.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        #region CRUD
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        #endregion

        #region Queries
        TEntity GetById(long id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region Transact
        bool SaveChanges();
        #endregion
    }
}
