using Microsoft.AspNetCore.Mvc;
using MyFrstMVCApp.Models;


namespace MyApp.Namespace
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            var movies=_db.Movies.ToList();
            return View(movies);
        }
        private List<Movie> GetAllMovies(){
            return new List<Movie>{
                new Movie{Id=1, Title="The Godfather"},
                new Movie{Id=2, Title="The Dark Knight"},
                new Movie{Id=3, Title="Inception"},
                new Movie{Id=4, Title="The Matrix"},
                new Movie{Id=5, Title="Interstellar"},
                new Movie{Id=6, Title="The Lion King"},
            };

        }
        //GET: Affiche le formulaire de création
        public IActionResult Create()
        {
            return View();
        }

        //POST: Crée un film
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            if(ModelState.IsValid){
                _db.Movies.Add(movie);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
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
