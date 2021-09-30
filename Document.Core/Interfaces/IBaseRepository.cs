using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Document.Core.Interfaces
{
    public interface IBaseRepository<T> where T:class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        T Find(Expression<Func<T, bool>> match, string[] includes = null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] includes = null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> match, int take, int skip);
        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        T Update(T entity);
        void Delete(int id);
        void DeleteRange(IEnumerable<T> entities);
        bool Check(string x);
    }
}
