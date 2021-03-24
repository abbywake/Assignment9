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

        public IActionResult ViewMovies()
        {
            return View(Context.Movies1);
            //if there is more than 0 movies, then put a certain page, if not, go to another page. 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
