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
            ViewBag.ErrorMessage = TempData["ErrorMessage"];
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View();
        }

        public IActionResult FiltroReservas()
        {
            return View();
        }



        [HttpPost]
        public IActionResult ObtenerHabitaciones(FiltroReserva datos)
        {

            DatosReserva_aux aux = new DatosReserva_aux();
            aux.fechaIngreso = datos.fechaInicio;
            aux.fechaEgreso = datos.fechaFinal;
            aux.habitacionesDisponibles = context.Habitaciones.ToList();
            aux.habitacionesDisponibles.RemoveAll(h => h.capacidad < datos.cantidadPersonas);
            aux.habitacionesDisponibles.RemoveAll(habitacion => context.Reservas.Any(reservada =>
            reservada.nroHabitacion == habitacion.numHabitacion &&
            ((reservada.fechaIngreso <= aux.fechaIngreso && aux.fechaIngreso <= reservada.fechaEgreso)
            || (reservada.fechaIngreso <= aux.fechaEgreso && aux.fechaEgreso <= reservada.fechaEgreso))));

            /*var habitacionesFiltradas = aux.habitacionesDisponibles.Where(habitacion => context.Reservas.Any(reservada =>
            reservada.nroHabitacion == habitacion.numHabitacion&& 
            !((reservada.fechaIngreso <= aux.fechaIngreso && aux.fechaIngreso <= reservada.fechaEgreso) 
            || (reservada.fechaIngreso <= aux.fechaEgreso && aux.fechaEgreso <= reservada.fechaEgreso)) ));*/
            /*||  (r.fechaIngreso >= aux.fechaIngreso && r.fechaEgreso <= aux.fechaEgreso)*/

            /*var habitacionesFiltradas = aux.habitacionesDisponibles.Where(h => !context.Reservas.Any(r =>
                r.nroHabitacion == h.numHabitacion &&
                ((r.fechaIngreso <= aux.fechaIngreso && r.fechaEgreso > aux.fechaIngreso) ||
                (r.fechaIngreso < aux.fechaEgreso && r.fechaEgreso >= aux.fechaEgreso) ||
                (r.fechaIngreso >= aux.fechaIngreso && r.fechaEgreso <= aux.fechaEgreso))
                    ));
            */


            return View("Reservar", aux);

        }

        [HttpPost]
        public ActionResult AgregarReserva(DatosReserva_aux datos)
        {
            try
            {
                Reserva reserva = new Reserva()
                {
                    titular = datos.titular,
                    nroHabitacion = datos.nroHabitacion,
                    pagado = datos.pagado,
                    idMedioPago = datos.idMedioPago,
                    fechaIngreso = datos.fechaIngreso,
                    fechaEgreso = datos.fechaEgreso,
                };
                context.Reservas.Add(reserva);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "No se pudo generar la reserva";
                return RedirectToAction(nameof(Index));
            }

            TempData["SuccessMessage"] = "Se ha generado su reserva :)";
            return RedirectToAction("Index");
        }

        public IActionResult CheckIn()
        {
            return View();
        }

        public IActionResult CheckOut()
        {
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