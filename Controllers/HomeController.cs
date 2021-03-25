using Assignment9.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment9.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly ILogger<HomeController> _logger;

        //getting the context in here 
        private MovieDBContext Context { get; set; }

        //private BookListViewModel hello { get; set; }

        //constructor gets set and then we are bringing in the context
        public HomeController(ILogger<HomeController> logger, MovieDBContext con )
        {
            _logger = logger;
            Context = con;
        }

        public IActionResult Index()
        {
            return View(
                new BookListViewModel
                {
                    addMovies = Context.Movies1
                });
                
                
        }

        public IActionResult Podcast()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddMovies()
        {
            return View();
        }
        [HttpPost]

        public IActionResult AddMovies(addMovie submittedForm)
        {
            if (ModelState.IsValid)
            {
                Context.Movies1.Add(submittedForm);
                Context.SaveChanges();
                return View("Index");
            }
            else
            {
                return View();
            }
        }
        //passing in the model 
        public IActionResult ViewMovies()
        {
            return View(Context.Movies1);
            //if there is more than 0 movies, then put a certain page, if not, go to another page. 
        }

        //public IActionResult ViewMovies()
        //{
        //    return View(Context.Movies1);
        //    //if there is more than 0 movies, then put a certain page, if not, go to another page. 
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //deleting. Takes the one where 
        [HttpPost]
        public IActionResult RemoveMovie(long Rachel)
        {
            IQueryable<addMovie> removingMovie = Context.Movies1.Where(m => m.MovieID == Rachel);

            foreach(var i in removingMovie)
            {
                Context.Movies1.Remove(i);
            }

            Context.SaveChanges();

            return View("Index", Rachel);
        }

        //This takes the parameter passed and passes it to the edit file. 
        [HttpPost]
        public IActionResult EditMovie(long Hello)
        {
            addMovie removingMovie = Context.Movies1.Where(m => m.MovieID == Hello).FirstOrDefault();

            return View(removingMovie);
        }

        //SubmitEditMovie IActionResult takes whatever you are passing through to edit and then it updates and saves it. 
        [HttpPost]
        public IActionResult SubmitEditMovie(addMovie editMovie)
        {
            IQueryable<addMovie> edit_movie = Context.Movies1.Where(m => m.MovieID == editMovie.MovieID);
            if(ModelState.IsValid)
            {
                foreach (var x in edit_movie)
                    {
                        x.Title = editMovie.Title;
                        x.Category = editMovie.Category;
                        x.Year = editMovie.Year;
                        x.DirectorFName = editMovie.DirectorFName;
                        x.DirectorLName = editMovie.DirectorLName;
                        x.Rating = editMovie.Rating;
                        x.Edited = editMovie.Edited;
                        x.LentTo = editMovie.LentTo;
                        x.Notes = editMovie.Notes;
                    }
            }


            Context.Movies1.Update(editMovie);
            Context.SaveChanges();
            return RedirectToAction("ViewMovies");
            

            

        }
    }
}
