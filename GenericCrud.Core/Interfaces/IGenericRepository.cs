using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCrud.Core.Interfaces
{
    public interface IGenericRepository<T>
    {
        int Add(T entity);
        bool Update(T entity);
        T Get(int ID);
        IEnumerable<T> GetAll();
        bool Delete(T entity);
        bool Delete(int ID);
        bool DeleteAll();
        bool Remove(T entity);
        bool Remove(int ID);
        bool RemoveAll();
    }
}
