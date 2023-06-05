using Microsoft.AspNetCore.Mvc;
using ReservaHoteles_TPFinal.Context;
using ReservaHoteles_TPFinal.Models;
using System.Diagnostics;

namespace ReservaHoteles_TPFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Hotel_context context = new Hotel_context();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Habitacion> Habitaciones = new List<Habitacion>();
            Habitaciones = context.Habitaciones.ToList();
            return View(Habitaciones);
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