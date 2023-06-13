using Microsoft.AspNetCore.Mvc;
using ReservaHoteles_TPFinal.Models;
using ReservaHoteles_TPFinal.Context;

namespace ReservaHoteles_TPFinal.Controllers
{
    public class ReservasController : Controller
    {
        private readonly Hotel_context context = new Hotel_context();


        public void BuscarReserva(FiltroCheckIn datos)
        {
            Reserva reservaBuscada = new Reserva();
            Habitacion habBuscada = new Habitacion();

            String nombreReserva = datos.titularReserva;
            reservaBuscada = context.Reservas.Where(r => r.titular.Equals(nombreReserva)).FirstOrDefault();
            // Validar fecha? fechaIngreso de la reserva = fechaActual

            if (reservaBuscada != null) 
            {
                Console.WriteLine("Reserva Encontrada");
                 habBuscada = context.Habitaciones.Where(h => h.numHabitacion == reservaBuscada.nroHabitacion).FirstOrDefault();
                 
                if(habBuscada != null)
                {
                    habBuscada.ocupada = true;
                }

                // Pendiente: registrar a las personas (Add) y modificar estado Habitacion en BBDD
                //context.SaveChanges();
            }

            /*
                1. Que hacemos si esta ocupada? NO DEBERIA PASAR QUE ESTE OCUPADA, POR ESO FILTRO AL RESERVAR
                
                2. Habria que eliminar la reserva de la base de datos? NO, debe quedar historial. 
                O no hacemos nada o agregamos algun atributo booleano.
            */

        }
    }


}
