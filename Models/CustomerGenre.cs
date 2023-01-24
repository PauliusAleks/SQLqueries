using Assignment2_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_BackEnd.Models
{
    public class CustomerGenre
    {
        public Customer Customer { get; set; }
        public int QuanitityFavoriteGenreRecordsBought { get; set; }
        public string GenreName { get; set; }

    }
}
