using AbCorFlorProyectoP2EasyTicketsMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AbCorFlorProyectoP2EasyTicketsMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult ACFIndex()
        {
            return View();
        }

        public IActionResult ACFPrivacy()
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
