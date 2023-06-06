using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            /*List<Habitacion> Habitaciones = new List<Habitacion>();
            Habitaciones = context.Habitaciones.ToList();
            return View(Habitaciones);*/
            return View();
        }
        public List<Habitacion> ObtenerHabitaciones(int cantidadPersonas)
        {
            // Faltaria filtrar x fechas, pero son datos de las reservas no de la habitacion
            var habitaciones = context.Habitaciones
                .Where(h => h.capacidad >= cantidadPersonas)
                .ToList();

            return habitaciones;
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