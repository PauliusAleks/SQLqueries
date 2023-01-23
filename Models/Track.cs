using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2_BackEnd.Models;

namespace Assignment2_BackEnd.Models
{
    internal class Track
    {
        public int TrackId { get; set; }
        public int GenreId { get; set; }

        public Track() { }
        public Track(int trackId, int genreId)
        {
            TrackId = trackId;
            GenreId = genreId;
        }

    }
}
