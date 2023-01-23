using Assignment2_BackEnd.Models.CustomerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_BackEnd.Repositories.CustomerGenreRepository
{
    public interface ICustomerGenreRepository
    {
        public List<string> GetFavoriteGenre(Customer customer);
    }
}
