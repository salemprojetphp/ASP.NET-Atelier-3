using Microsoft.AspNetCore.Mvc;
using MyFrstMVCApp.Models;

namespace MyApp.Namespace
{
    public class MovieClientController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MovieClientController(ApplicationDbContext db)
        {
            _db = db;
        }
        
    }
}
