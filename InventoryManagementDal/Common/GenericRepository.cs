using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace InventoryManagementDAL.Common
{
    public class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
    {
        private readonly DbContext _context;
        public DbContext Context
        {
            get
            {
                return _context;
            }
        }

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(T t)
        {
            _context.Set<T>().Add(t);
            _context.SaveChanges();
        }

        public void Delete(T t)
        {
            _context.Set<T>().Remove(t);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(long id)
        {
             return _context.Set<T>().Find(id);
        }

        public void DeleteById(long id)
        {
            T t = _context.Set<T>().Find(id);

            if (t != null)
            {
                _context.Set<T>().Remove(t);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"failed to find object with id:{id}");
            }
        }

        public void Update(T t)
        {           
            _context.Set<T>().Update(t);
            _context.SaveChanges();
        }

        public List<T> GetByFilter(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).ToList();
        }

        public string GenerateScript()
        {
            return Context.Database.GenerateCreateScript();          
        }
        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

