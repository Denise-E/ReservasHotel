using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ReservaHoteles_TPFinal.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string titular { get; set; }

        [Required]
        public int nroHabitacion { get; set; }

        [Required]
        public bool pagado { get; set; }

        [Required]
        public int idMedioPago { get; set; }
        
        [Required]
        public DateTime fechaIngreso { get; set; }

        [Required]
        public DateTime fechaEgreso { get; set; }

    }
}
