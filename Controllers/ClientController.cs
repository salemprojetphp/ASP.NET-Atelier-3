using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFrstMVCApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyApp.Namespace
{
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ClientController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: ClientController
        // public ActionResult Index()
        // {
        //     return View(GetAllClients());
        // }

        // private List<Client> GetAllClients()
        // {
        //     return new List<Client>
        //     {
        //         new Client { Id = 1, Name = "John Doe" },
        //         new Client { Id = 2, Name = "Jane Doe" },
        //         new Client { Id = 3, Name = "Alice" },
        //         new Client { Id = 4, Name = "Bob" },
        //         new Client { Id = 5, Name = "Charlie" },
        //         new Client { Id = 6, Name = "David" },
        //     };
        // }
        public ActionResult Index()
        {
            var clients = _db.Clients.Include(c => c.MembershipType).ToList();
            return View(clients);
        }

        //GET: Client/Create
        public IActionResult Create()
        {
            var members= _db.MembershipTypes.ToList();
            ViewBag.members=members.Select(m=>new SelectListItem
            {
                Value=m.Id.ToString()
            });
            return View();
        }

        [HttpPost]
        public IActionResult Create(Client client)
        {
            if(!ModelState.IsValid)
            {
                var members= _db.MembershipTypes.ToList();
                ViewBag.members=members.Select(m=>new SelectListItem
                {
                    Value=m.Id.ToString()
                });
                ViewBag.Errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return View(client);
           }
            client.Id = _db.Clients.Any() ? _db.Clients.Max(c => c.Id) + 1 : 1;
            _db.Clients.Add(client);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
