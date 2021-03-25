using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Assignment9.Models
{
    //context for the DB
    public class MovieDBContext : DbContext
    {
        public MovieDBContext (DbContextOptions<MovieDBContext> options) : base (options)
        {
        
        }
        public DbSet<addMovie> Movies1 { get; set; }
    }
}
