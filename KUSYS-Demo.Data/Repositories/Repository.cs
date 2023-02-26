using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Data.Repositories
{
    public class Repository<T>: IRepository<T> where T : class
    {
        public Repository() { }
        public void Add(T entity)
        {
            if (entity != null)
            {
                using var c = new Context();
                c.Add(entity);
                c.SaveChanges();
            }
        }
        public void Update(T entity)
        {
            if (entity != null)
            {
                using var c = new Context();
                c.Update(entity);
                c.SaveChanges();
            }
        }
        public void Delete(T entity)
        {
            if (entity != null)
            {
                using var c = new Context();
                c.Remove(entity);
                c.SaveChanges();
            }
        }
        public IEnumerable<T> GetAll()
        {
            using var c = new Context();
            return c.Set<T>().ToList();
        }
        public T? GetById(object id)
        {
            using var c = new Context();
            return c.Set<T>().Find(id);
        }
    }
}
