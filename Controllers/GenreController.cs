using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    public class GenreController : Controller
    {
        private readonly ApplicationDbContext _db;
        public GenreController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: GenreController
        public ActionResult Index()
        {
            var genres=_db.Genres.ToList();
            return View(genres);
        }
        //GET: Affiche le formulaire de création
        public IActionResult Create()
        {
            return View();
        }

        //POST: Crée un genre
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Genre genre)
        {
            if(ModelState.IsValid){
                _db.Genres.Add(genre);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genre);
        }

    }
}
