namespace ReservaHoteles_TPFinal.Models
{
    public class DatosReserva_aux
    {
        //public Reserva reservaAux = new Reserva();
        public string titular { get; set; }
        public int nroHabitacion { get; set; }
        public bool pagado { get; set; } = false;
        public int idMedioPago { get; set; }
        public DateTime fechaIngreso { get; set; }
        public DateTime fechaEgreso { get; set; }

        public Habitacion habitacionAux = new Habitacion();

        public List<Habitacion> habitacionesDisponibles = new List<Habitacion>();

    }
}
