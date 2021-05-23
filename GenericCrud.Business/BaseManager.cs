using GenericCrud.Core.Interfaces;
using GenericCrud.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCrud.Business
{
    public class BaseManager<T> : IGenericRepository<T> where T : class
    {
        private readonly IGenericRepository<T> repo;
        public BaseManager()
        {
            repo = new BaseRepository<T>();
        }

        public int Add(T entity)
        {
            return repo.Add(entity);
        }

        public bool Delete(T entity)
        {
            return repo.Delete(entity);
        }

        public bool Delete(int ID)
        {
            return repo.Delete(ID);
        }

        public bool DeleteAll()
        {
            return repo.DeleteAll();
        }

        public T Get(int ID)
        {
            return repo.Get(ID);
        }

        public IEnumerable<T> GetAll()
        {
            return repo.GetAll();
        }

        public bool Remove(T entity)
        {
            return repo.Remove(entity);
        }

        public bool Remove(int ID)
        {
            return repo.Remove(ID);
        }

        public bool RemoveAll()
        {
            return repo.RemoveAll();
        }

        public bool Update(T entity)
        {
            return repo.Update(entity);
        }

        public bool Update(T entityOld, T entityNews)
        {
            return repo.Update(entityOld, entityNews);
        }
    }
}
