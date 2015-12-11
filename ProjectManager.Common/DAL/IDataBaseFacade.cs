using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjectManager.Common.DAL
{
    public interface IDataBaseFacade
    {
        IEnumerable<T> GetAll<T>() where T : class;
        IEnumerable<T> GetBy<T>(Expression<Func<T, bool>> predicate) where T : class;
        T GetById<T>(Guid id) where T : class;
        T GetById<T>(string id) where T : class;
        T Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Attach<T>(T entity) where T : class;
        T Delete<T>(T entity) where T : class;
        T Delete<T>(string id) where T : class;
        void Save<T>() where T : class;

        IEnumerable<T> Query<T>(string query) where T : class;
    }
}
