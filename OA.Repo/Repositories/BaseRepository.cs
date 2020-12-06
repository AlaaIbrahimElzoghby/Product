using Microsoft.EntityFrameworkCore;
using OA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OA.Repo.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {

        #region Fields
        protected ApplicationContext _context;
        protected readonly DbSet<TEntity> _entities;
        #endregion

        #region Constructor
        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }
        #endregion

        #region CRUD
        public void Insert(TEntity entity)
        {
            try
            {
                _entities.Add(entity);

            }
            catch (Exception e)
            {
                // we can log exception here in exception table
            }

        }
        public void Update(TEntity entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception e)
            {
                // we can log exception here in exception table
            }
        }
        public void Delete(TEntity entity)
        {
            try
            {
                _entities.Remove(entity);
            }
            catch (Exception e)
            {
                // we can log exception here in exception table
            }
        }
        #endregion

        #region Queries
        public TEntity GetById(long id)
        {
            try
            {
                return _entities.Find(id);
            }
            catch (Exception e)
            {
                // we can log exception here in exception table
                return null;
            }
        }
        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _entities.AsEnumerable();
            }
            catch (Exception e)
            {
                // we can log exception here in exception table
                return null;
            }
        }
        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return _entities.Where(predicate);
            }
            catch (Exception e)
            {
                // we can log exception here in exception table
                return null;
            }
        }
        #endregion


        public bool SaveChanges()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                // we can log exception here in exception table
                return false;
            }

        }

    }

}
