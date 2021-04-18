using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            //var movies = _context.Customers.Include(c => c.MembershipType).ToList();
            var movies = _context.Movies.Include(g => g.Genre).ToList();
            return View(movies);
        }
        // GET: Customers
        public ActionResult Details(int id)
        {
            //var movies = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            var movies = _context.Movies.Include(g => g.Genre).SingleOrDefault(m => m.Id == id);
            if (movies == null)
            {
                return HttpNotFound();
            }

            return View(movies);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            bool idHasValue = movie.Id != null ? true : false;
            if (!ModelState.IsValid)
            {
                var viewModel = new RandomMovieViewModel
                {
                    Genre = _context.Genres.ToList(),
                    Id = movie.Id,
                    Name = movie.Name,
                    GenreId = movie.GenreId,
                    ReleaseDate = DateTime.Now,
                    Stock = movie.Stock
                };
                return View("NewMovie", viewModel);
            }
            if (movie.Id == 0)
            {
                var context = new Movie()
                {
                    Name = movie.Name,
                    ReleaseDate = movie.ReleaseDate,
                    GenreId = movie.GenreId,
                    Stock = movie.Stock
                };

                _context.Movies.Add(context);
            }
            else
            {
                var moviesInDB = _context.Movies.Single(m => m.Id == movie.Id);

                moviesInDB.Name = movie.Name;
                moviesInDB.ReleaseDate = movie.ReleaseDate;
                moviesInDB.GenreId = movie.GenreId;
                moviesInDB.Stock = movie.Stock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }


        public ActionResult NewMovie()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new RandomMovieViewModel()
            {
                Genre = genres
            };

            return View("NewMovie", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movies = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movies == null)
            {
                return HttpNotFound();
            }

            var viewModel = new RandomMovieViewModel()
            {
                Id = movies.Id,
                Name = movies.Name,
                GenreId = movies.GenreId,
                ReleaseDate = movies.ReleaseDate,
                Stock = movies.Stock,
                Genre = _context.Genres.ToList()
            };

            return View("NewMovie", viewModel);
        }
    }
}