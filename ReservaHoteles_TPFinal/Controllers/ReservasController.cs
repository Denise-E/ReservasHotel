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

            try
            {

                reservaBuscada = BuscarReserva(datos);
                if (reservaBuscada == null)
                {
                    TempData["ErrorMessage"] = "No se encontro una reserva con ese nombre :(";
                }
                else
                {
                    TempData["ErrorMessage"] = "Papi, viniste antes de tiempo :(";
                    ValidarFecha(reservaBuscada.fechaIngreso);
                }
                habBuscada = context.Habitaciones.Where(h => h.numHabitacion == reservaBuscada.nroHabitacion).FirstOrDefault();
                TempData["ErrorMessage"] = "No se encontro la habitacion :(";
                habBuscada.ocupada = true;
                //registrarTitular(datos);
                context.Habitaciones.Update(habBuscada);
                context.SaveChanges();
                TempData["SuccessMessage"] = "Se ha generado el checkIn :)";
                TempData["ErrorMessage"] = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return RedirectToAction(nameof(Index), "Home");
        }

        private void ValidarFecha(DateTime fechaIngreso)
        {
            if (fechaIngreso.Date < DateTime.Today)
            {
                throw new InvalidDataException("Fecha Invalida");
            }
        }


        private void registrarTitular(FiltroCheckIn datos)
        {
            throw new NotImplementedException();
        }

        public IActionResult CheckOut(FiltroCheckIn datos)
        {
            Reserva reservaBuscada = new Reserva();
            Habitacion habBuscada = new Habitacion();
            try
            {
                TempData["ErrorMessage"] = "No se encontro una reserva con ese nombre :(";
                reservaBuscada = BuscarReserva(datos);
                habBuscada = context.Habitaciones.Where(h => h.numHabitacion == reservaBuscada.nroHabitacion).FirstOrDefault();
                habBuscada.ocupada = false;
                context.Habitaciones.Update(habBuscada);
                context.Habitaciones.Update(habBuscada);
                context.SaveChanges();
                TempData["SuccessMessage"] = "Chau chau :)";
                TempData["ErrorMessage"] = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


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
