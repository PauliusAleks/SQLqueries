using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_BackEnd.Repositories
{
    public interface IRepository<T, U, V, A>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
