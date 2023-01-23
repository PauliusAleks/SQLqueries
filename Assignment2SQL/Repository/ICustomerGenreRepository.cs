using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2SQL.Model;

namespace Assignment2SQL.Repository
{
    public interface ICustomerGenreRepository
    {
        public CustomerGenre GetCustomerGenres();
    }
}
