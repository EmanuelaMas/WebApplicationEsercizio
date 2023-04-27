using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using WebApplication1.Filter;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Login(bool showerror)
        {
            if (HttpContext.Session.GetString("LogSession") != null)
            {
                return RedirectToAction("Index");
            }
            return View(new UtenteLoggato(showerror));
        }

        [HttpPost]
        public IActionResult Login(Utente u)
        {
            var log = DatabaseSito.Login(u.Username);
            if (log != "0")
            {
                HttpContext.Session.SetString("LogSession", log);
            }
            else
            {
                HttpContext.Session.Remove("LogSession");
                return RedirectToAction("Login", new { showerror = true });
            }

            return RedirectToAction("Index");
        }

        [FiltroAuth]
        public IActionResult Index()
        {
            //per visualizzare 
            return View(DatabaseSito.GetProdotti());
        }
        [FiltroAuth]
        public IActionResult Logout(int id)
        {
            var prod = DatabaseSito.GetProdotto(id);
            return View(prod);
        }
        [HttpPost]
        [FiltroAuth]
        public IActionResult Logout(Prodotto prod)
        {
            var p = DatabaseSito.GetProdotto(prod.Id);
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}