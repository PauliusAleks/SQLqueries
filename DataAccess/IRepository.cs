using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_BackEnd.DataAccess
{
    /// <summary>
    /// Generic Base Interface to implement Repository Pattern.
    /// Any custom made Repository can implement IRepository<T> to retrieve CRUD methods.
    /// </summary>
    /// <typeparam name="T">T can be used to any model.</typeparam>
    public interface IRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
