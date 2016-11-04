using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
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

        // GET: Movies
        public ActionResult Index()
        {

            var movies = _context.Movies.Include(c=>c.Genre).ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {

            var movie = _context.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == id);

            return View(movie);
        }


    }
}