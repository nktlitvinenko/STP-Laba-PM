using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ProjectManager.Common.DAL.Repositories;

namespace ProjectManager.DAL.ProxyRepositories
{
    public abstract class GenericProxyRepository<T> : IGenericRepository<T> where T : Entity.Abstract.Entity
    {
        private IGenericRepository<T> _context;
        private List<T> _cache;

        public GenericProxyRepository(IGenericRepository<T> context)
        {
            _context = context;
            _cache = new List<T>();
        }

        public IGenericRepository<T> Context
        {
            get { return _context; }
        }

        public IEnumerable<T> GetAll()
        {
            return _context.GetAll();
        }

        public IEnumerable<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            return _context.GetBy(predicate);
        }

        public T GetById(Guid id)
        {
            var result = _cache.SingleOrDefault(t => t.Id == id);

            if (result != null)
                return result;

            return id == Guid.Empty ? null : _context.GetById(id);
        }

        public T GetById(string id)
        {
            var result = _cache.SingleOrDefault(t => t.Id == new Guid(id));

            if (result != null)
                return result;

            return string.IsNullOrEmpty(id) ? null : _context.GetById(id);
        }

        public T Add(T entity)
        {
            _cache.Add(entity);

            return _context.Add(entity);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }

        public void Attach(T entity)
        {
            _context.Attach(entity);
        }

        public T Delete(T entity)
        {
            _cache.Remove(entity);

            return _context.Delete(entity);
        }

        public T Delete(string id)
        {
            var entity = GetById(id);

            if (entity != null)
                _cache.Remove(entity);

            return _context.Delete(id);
        }

        public void Save()
        {
            _context.Save();
        }
    }
}
