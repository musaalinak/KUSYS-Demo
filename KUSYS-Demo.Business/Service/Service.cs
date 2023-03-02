using KUSYS_Demo.Data;
using KUSYS_Demo.Data.Models;
using KUSYS_Demo.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Business.Service
{
    public class Service<T> : IService<T> where T : class
    {
        IRepository<T> repository;
        public Service(IRepository<T> _repository)
        {
            repository= _repository;
        }

        public List<T> GetList()
        {
            return repository.GetAll().ToList();
        }
        public T GetById(object id) {
            return repository.GetById(id);
        }
        public void Add(T entity) {
            repository.Add(entity);
        }
        public void Update(T entity)
        {
            repository.Update(entity);
        }
        public void Delete(T entity)
        {
            repository.Delete(entity);
        }
    }
}
