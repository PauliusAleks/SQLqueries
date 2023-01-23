using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_BackEnd.Models.GenreModel
{
    internal class Genre : IGenre
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
