using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebData
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        void Save();
    }
}
