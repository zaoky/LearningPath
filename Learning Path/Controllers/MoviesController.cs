using System.Web.Mvc;
using Learning_Path.Models;

namespace Learning_Path.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            Movie movie = new Movie()
            {
                Name = "Shrek!"
            };
            return View(movie);
        }
    }
}