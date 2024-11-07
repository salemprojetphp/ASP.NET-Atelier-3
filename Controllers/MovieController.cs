using Microsoft.AspNetCore.Mvc;
using MyFrstMVCApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostingEnvironment;
        public MovieController(ApplicationDbContext db, IWebHostEnvironment webHostingEnvironment)
        {
            _db = db;
            _webHostingEnvironment = webHostingEnvironment;
        }
        public ActionResult Index()
        {
            var movies=_db.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }
        //GET: Affiche le formulaire de création
        public IActionResult Create()
        {
            return View();
        }

        //POST: Crée un film
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie, IFormFile photo)
        {
            if(!ModelState.IsValid){
                return View(movie);
            }

            if(photo != null) {
                var fileName = Path.Combine(_webHostingEnvironment.WebRootPath, "images", Path.GetFileName(photo.FileName));
                photo.CopyTo(new FileStream(fileName, FileMode.Create));
                movie.photo = "images/" + photo.FileName;
            }

            _db.Movies.Add(movie);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

       //GET: Trouve un film
        public IActionResult Edit(int id)
        {
            var movie=_db.Movies.Find(id);
            if(movie==null){
                return NotFound();
            }
            return View(movie);
        }

        //POST: Modifie un film
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie movie)
        {
            if(ModelState.IsValid){
                _db.Movies.Update(movie);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        //GET: Trouve un film
        public IActionResult Delete(int id)
        {
            var movie=_db.Movies.Find(id);
            if(movie==null){
                return NotFound();
            }
            return View(movie);
        }

        //POST: Supprime un film
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id){
            var movie=_db.Movies.Find(id);
            if(movie==null){
                return NotFound();
            }
            _db.Movies.Remove(movie);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
