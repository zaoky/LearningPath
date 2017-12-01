using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Learning_Path.Models;

namespace Learning_Path.Controllers
{
    public class MoviesController : Controller
    {
        #region Fields
        private ApplicationDbContext _context;
        #endregion

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            List<Movie> movies = _context.Movies.Include(c => c.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            Movie cust = this._context.Movies.Include(c => c.Genre).FirstOrDefault(c => c.Id == id);
            return View(cust ?? new Movie { Id = -1, Name = "Movies" });
        }

        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 12)}")] //constraints atribute route
        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content($"{year}/{month}");
        }
    }
}