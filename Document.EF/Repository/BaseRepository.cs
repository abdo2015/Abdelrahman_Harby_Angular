using Document.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Document.EF.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }
        
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }


        public T Find(Expression<Func<T, bool>> match, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
                foreach (var incluse in includes)
                {
                    query = query.Include(incluse);

                }

            return query.SingleOrDefault(match);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
                foreach (var incluse in includes)
                {
                    query = query.Include(incluse);

                }

            return query.Where(match).ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, int take, int skip)
        {
            return _context.Set<T>().Where(match).Skip(skip).Take(take).ToList();
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
          //  _context.SaveChanges();
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
            return entities;
        }

        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }

        public void Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
            
            _context.Set<T>().Remove(entity);
        }
        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
        public bool Check(string x)
        {
            var check =_context.Set<T>().Find(x);
            return check != null ;
        }
    }
}
