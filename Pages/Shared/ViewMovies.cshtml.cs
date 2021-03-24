using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment9.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment9.Pages
{
    public class ViewMoviesModel : PageModel
    {

        private MovieDBContext repository;
        public string ReturnUrl { get; set; }
        public ViewMoviesModel(MovieDBContext other, Display cartservice)
        {
            repository = other;
            Display = cartservice;
        }
        public Display Display { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(long movieID, string returnUrl)
        {
            addMovie movie= repository.Movies1
                .FirstOrDefault(p => p.MovieID == movieID);
            Display.AddItem(movie, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(long movieId, string returnUrl)
        {
            Display.RemoveLine(Display.Lines.First(cl =>
                cl.addMovie.MovieID == movieId).addMovie);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
