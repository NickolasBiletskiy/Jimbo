using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Data.DbContext;
using Data.Entities;

namespace Data
{
    public class Repository<T> : IDisposable where T : BaseEntity
    {
        private readonly EntityContext _entityContext;
        private DbSet<T> _dbSet;

        #region .cstor
        public Repository(EntityContext entityContext)
        {
            _entityContext = entityContext;
            _dbSet = _entityContext.Set<T>();
        }
        #endregion

        #region Public Methods

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetWhere(Expression<Func<T, bool>>  exp)
        {
            return _dbSet.FirstOrDefault(exp);
        }

        public T Add(T value)
        {
            _dbSet.Add(value);
            _entityContext.SaveChanges();
            return value;
        }

        public void SaveChanges()
        {
            _entityContext.SaveChanges();
        }

        #endregion

        public void Dispose()
        {
            _entityContext.Dispose();
        }
    }
}