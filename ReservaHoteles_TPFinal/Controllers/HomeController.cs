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
            return View();
        }

        [HttpPost]
        public IActionResult ObtenerHabitaciones(FiltroReserva datos)
        {

            DatosReserva_aux aux = new DatosReserva_aux();
            aux.habitacionesDisponibles = context.Habitaciones.Where(h => h.capacidad >= datos.cantidadPersonas).ToList();

            aux.reservaAux.fechaIngreso = datos.fechaInicio;
            aux.reservaAux.fechaEgreso = datos.fechaFinal;

            var habitacionesFiltradas = aux.habitacionesDisponibles.Where(h => !context.Reservas.Any(r =>
                    r.nroHabitacion == h.Id &&
                    r.fechaIngreso <= datos.fechaInicio ||
                    r.fechaEgreso > datos.fechaFinal));

            aux.habitacionesDisponibles = habitacionesFiltradas.ToList();

            return View("Reservar", aux);
        }

        [HttpPost]
        public void AgregarReserva(DatosReserva_aux datos)
        {
            Console.WriteLine("DATOS" + datos);

            // Habria que ponerlo dentro de try y catch...

            Reserva reserva = new Reserva()
            {
                titular = datos.reservaAux.titular,
                nroHabitacion = datos.reservaAux.nroHabitacion,
                fechaIngreso = datos.reservaAux.fechaIngreso,
                fechaEgreso = datos.reservaAux.fechaEgreso,
                idMedioPago = datos.reservaAux.idMedioPago,
            };
            
            Console.WriteLine("Titular " + reserva.titular, " Hab " + reserva.nroHabitacion);
            //datos.reservaAux;
            context.Reservas.Add(reserva);
            context.SaveChanges();
            // Se guarda pero mal los valores.
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