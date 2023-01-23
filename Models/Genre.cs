using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_BackEnd.Models
{
    internal class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        public Genre(int genreId, string name)
        {
            GenreId = genreId;
            Name = name;
        }
    }
}
