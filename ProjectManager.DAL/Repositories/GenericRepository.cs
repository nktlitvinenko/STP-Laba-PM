using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ProjectManager.Common.DAL;
using ProjectManager.Common.DAL.Repositories;

namespace ProjectManager.DAL.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class 
    {
        protected IDataContext _context;

        public GenericRepository(IDataContext context)
        {
            _context = context;
        }

        public IDataContext Context
        {
            get { return _context; }
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public IEnumerable<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public T GetById(Guid id)
        {
            return id == Guid.Empty ? null : _context.Set<T>().Find(id);
        }

        public T GetById(string id)
        {
            return string.IsNullOrEmpty(id) ? null : _context.Set<T>().Find(new Guid(id));
        }

        public T Add(T entity)
        {
            return _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Attach(T entity)
        {
            _context.Set<T>().Attach(entity);
        }

        public T Delete(T entity)
        {
            return _context.Set<T>().Remove(entity);
        }

        public T Delete(string id)
        {
            return _context.Set<T>().Remove(GetById(new Guid(id)));
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
