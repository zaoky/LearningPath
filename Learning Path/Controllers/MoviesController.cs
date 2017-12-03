using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Learning_Path.Models;
using System;
using Learning_Path.ViewModels;
using System.Globalization;

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
            Movie mov = this._context.Movies.Include(c => c.Genre).FirstOrDefault(m => m.Id == id);
            return View(mov ?? new Movie { Id = -1, Name = "Movies" });
        }

        public ActionResult FormMovie(int id)
        {
            Movie mov = this._context.Movies.Include(c => c.Genre).FirstOrDefault(m => m.Id == id);
            MovieFormViewModel movieFormViewModel;
            if (mov == null)
            {
                movieFormViewModel = new MovieFormViewModel()
                {
                    Genres = _context.Genres.ToList(),
                };
            }
            else
            {
                movieFormViewModel = new MovieFormViewModel(mov)
                {
                    Genres = _context.Genres.ToList(),
                };
            }
            return View("MovieForm", movieFormViewModel);
        }

        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 12)}")] //constraints atribute route
        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content($"{year}/{month}");
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // to avoid cross site request forgery
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                MovieFormViewModel viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                Movie movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.StockNum = movie.StockNum;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }
}