using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        T? GetById(object id);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Delete(T entity);
        void Add(T entity);
    }
}
