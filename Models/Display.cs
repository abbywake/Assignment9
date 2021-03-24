using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment9.Models
{
    public class Display
    {
        public List<MovieLine> Lines { get; set; } = new List<MovieLine>();

        public virtual void AddItem (addMovie movie, int quantity)
        {
            MovieLine line = Lines.Where(m => m.addMovie.MovieID == movie.MovieID)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new MovieLine
                {
                    addMovie = movie,
                    Quantity = quantity,
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(addMovie addM) =>
            Lines.RemoveAll(x => x.addMovie.MovieID == addM.MovieID);

        public virtual void Clear() => Lines.Clear();

        public class MovieLine 
        {
            public int MovieLineID { get; set; }

            public addMovie addMovie { get; set; }

            public int Quantity { get; set; } 
        }

        
    }
}
