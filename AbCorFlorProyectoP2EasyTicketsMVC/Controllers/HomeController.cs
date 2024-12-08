using AbCorFlorProyectoP2EasyTicketsMVC.Models;
using AbCorFlorProyectoP2EasyTicketsMVC.Data;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AbCorFlorProyectoP2EasyTicketsMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AbCorFlorProyectoP2EasyTicketsMVCContext _context;


        public HomeController(AbCorFlorProyectoP2EasyTicketsMVCContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;

        }

        public async Task<IActionResult> ACFIndexAsync()
        {

            return View(await _context.ACFTicket.ToListAsync());
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
