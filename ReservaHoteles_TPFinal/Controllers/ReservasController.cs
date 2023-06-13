using Microsoft.AspNetCore.Mvc;
using ReservaHoteles_TPFinal.Models;
using ReservaHoteles_TPFinal.Context;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReservaHoteles_TPFinal.Controllers
{
    public class ReservasController : Controller
    {
        private readonly Hotel_context context = new Hotel_context();


        [HttpPost]
        public IActionResult CheckIn(FiltroCheckIn datos)
        {
            Reserva reservaBuscada = new Reserva();
            Habitacion habBuscada = new Habitacion();

            reservaBuscada = BuscarReserva(datos);

            if (reservaBuscada != null) 
            {
                Console.WriteLine("Reserva Encontrada");
                 habBuscada = context.Habitaciones.Where(h => h.numHabitacion == reservaBuscada.nroHabitacion).FirstOrDefault();
                if(habBuscada != null)
                {
                    habBuscada.ocupada = true;
                    context.Habitaciones.Update(habBuscada);
                    context.SaveChanges();
                    //registrarTitular(datos);
                    TempData["SuccessMessage"] = "Se ha generado el checkIn :)";
                } else
                {
                    TempData["ErrorMessage"] = "No se encontro la habitacion :(";
                }
              
            } else
            {
                TempData["ErrorMessage"] = "No se encontro una reserva con ese nombre :(";
            }

            return RedirectToAction(nameof(Index), "Home");
        }
        //Pendiente: registrar al titular (Add)
        private void registrarTitular(FiltroCheckIn datos)
        {
            throw new NotImplementedException();
        }

        public IActionResult CheckOut(FiltroCheckIn datos)
        {
            Reserva reservaBuscada = new Reserva();
            Habitacion habBuscada = new Habitacion();

            reservaBuscada = BuscarReserva(datos);
            
            return RedirectToAction(nameof(Index), "Home");
        }

        public Reserva BuscarReserva(FiltroCheckIn datos)
        {
            Reserva reservaBuscada = new Reserva();

            string nombreReserva = datos.titularReserva;
            reservaBuscada = context.Reservas.Where(r => r.titular.Equals(nombreReserva)).FirstOrDefault();

            return reservaBuscada;
        }
    }


}
