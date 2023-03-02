using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        Context context;
        public Repository(Context _context)
        {
            context = _context;
        }
        public void Add(T entity)
        {
            if (entity != null)
            {
                context.Add(entity);
                context.SaveChanges();
            }
        }
        public void Update(T entity)
        {
            if (entity != null)
            {
                context.Update(entity);
                context.SaveChanges();
            }
        }
        public void Delete(T entity)
        {
            if (entity != null)
            {
                context.Remove(entity);
                context.SaveChanges();
            }
        }
        public IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }
        public T? GetById(object id)
        {
            T entity = context.Set<T>().Find(id);
            context.Entry(entity).State = EntityState.Detached;
            return entity;
        }
    }
}
