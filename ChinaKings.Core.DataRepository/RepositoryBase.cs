using ChinaKings.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChinaKings.Core.DataRepository
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : BaseModel
    {
        protected DbContext _dbContext;
        private readonly IDbSet<T> _dbSet;

        protected RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }



        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            var entry = _dbContext.Entry<T>(entity);
            if (entry.State == EntityState.Detached)
                entry.State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                _dbSet.Remove(obj);
            _dbContext.SaveChanges();
        }

        public virtual bool DeleteById(long id)
        {
            var entity = _dbSet.SingleOrDefault(e => e.ID == id);
            if (null == entity || entity.ID != id) return false;
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }

        public virtual bool Exists(long id)
        {
            return null != _dbSet.Find(id);
        }

        public virtual bool Exists(Expression<Func<T, bool>> where)
        {
            return null != _dbSet.FirstOrDefault<T>(where);
        }

        public virtual T GetById(long id)
        {
            return _dbSet.Find(id);
        }

        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where<T>(where).FirstOrDefault();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable<T>();
        }

        public virtual IQueryable<T> GetQueryable(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where<T>(where);
        }
    }
}
