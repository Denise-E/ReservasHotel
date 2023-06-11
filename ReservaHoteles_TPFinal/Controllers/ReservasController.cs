using Microsoft.AspNetCore.Mvc;
using ReservaHoteles_TPFinal.Models;
using ReservaHoteles_TPFinal.Context;

namespace ReservaHoteles_TPFinal.Controllers
{
    public class ReservasController : Controller
    {
        private readonly Hotel_context context = new Hotel_context();


        public IActionResult BuscarReserva(FiltroCheckIn datos)
        {
            Reserva reservaBuscada = new Reserva();
            Habitacion habBuscada = new Habitacion();

            String nombreReserva = datos.titularReserva;
            reservaBuscada = context.Reservas.Where(r => r.titular.Equals(nombreReserva)).FirstOrDefault();

            if (reservaBuscada != null) 
            {
                 habBuscada = context.Habitaciones.Where(h => h.numHabitacion == reservaBuscada.nroHabitacion).FirstOrDefault();
            }

            if (habBuscada.ocupada) 
            {
                //Que hacemos si esta ocupada?
            }

            habBuscada.ocupada = true;


            //Habria que eliminar la reserva de la base de datos y registrar a las personas







            return View();
        }
    }


}
