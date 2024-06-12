using Cinema.Data;
using Cinema.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Movie> objMovieList = _db.Movies;
            return View(objMovieList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie obj)
        {
            if (ModelState.IsValid)
            {
                _db.Movies.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Movie created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var movieFromDb = _db.Movies.Find(id);
            if (movieFromDb == null)
            {
                return NotFound();
            }
            return View(movieFromDb);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie obj)
        {
            if (ModelState.IsValid)
            {
                _db.Movies.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Movie updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var movieFromDb = _db.Movies.Find(id);
            if (movieFromDb == null)
            {
                return NotFound();
            }
            return View(movieFromDb);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteMovie(int? id)
        {
            var movieFromDb = _db.Movies.Find(id);
            if (movieFromDb == null)
            {
                return NotFound();
            }
            _db.Movies.Remove(movieFromDb);
            _db.SaveChanges();
            TempData["success"] = "Movie deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
