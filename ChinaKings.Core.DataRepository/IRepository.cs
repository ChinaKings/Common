using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChinaKings.Core.DataRepository
{
    interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        bool DeleteById(long id);
        bool Exists(long id);
        bool Exists(Expression<Func<T, bool>> where);
        T GetById(long id);
        T Get(Expression<Func<T, bool>> where);
        IQueryable<T> GetAll();
        IQueryable<T> GetQueryable(Expression<Func<T, bool>> where);
    }
}
