using System.Collections.Generic;
using System.Web.Mvc;
using Learning_Path.Models;

namespace Learning_Path.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult Index()
        {
            List<Movie> movie = new List<Movie>
            {
                new Movie { Id=1, Name = "Shrek" },
                new Movie { Id=2, Name = "Wall-e" }
            };
            return View(movie);
        }
        
        

        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 12)}")] //constraints atribute route
        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content($"{year}/{month}");
        }
    }
}