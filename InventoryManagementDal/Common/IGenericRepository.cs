using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace InventoryManagementDAL.Common
{
    public interface IGenericRepository<T> where T : class
    {
        void Create(T t);
        void Update(T t);
        void Delete(T t);
        void DeleteById(long id);
        T GetById(long id);
        List<T> GetAll();
        List<T> GetByFilter(Expression<Func<T, bool>> expression);
        string GenerateScript();
    }
}
