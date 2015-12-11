using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjectManager.Common.DAL.Repositories
{
    public interface IGenericRepository<T> : IGenericRepository where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetBy(Expression<Func<T, bool>> predicate);
        T GetById(Guid id);
        T GetById(string id);
        T Add(T entity);
        void Update(T entity);
        void Attach(T entity);
        T Delete(T entity);
        T Delete(string id);
        void Save();
    }

    public interface IGenericRepository { }
}
