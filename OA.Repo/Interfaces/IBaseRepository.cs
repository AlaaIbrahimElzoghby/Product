using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OA.Repo.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        #region CRUD
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity enitity);
        #endregion

        #region Queries
        TEntity GetById(long id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        #endregion

        bool SaveChanges();
    }
}
