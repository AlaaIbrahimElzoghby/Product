using OA.Repo.Interfaces;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OA.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {

        #region Fields
        private IBaseRepository<TEntity> _repository;
        #endregion

        #region Constructors
        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }
        #endregion

        #region CRUD
        public void Insert(TEntity entity)
        {
            _repository.Insert(entity);
        }
        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }
        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }
        #endregion

        #region Queries
        public TEntity GetById(long id)
        {
            return _repository.GetById(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }
        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.FindBy(predicate);
        }
        #endregion

        #region Transact
        public bool SaveChanges()
        {
            return _repository.SaveChanges();
        }
        #endregion
    }
}
