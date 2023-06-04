using System.ComponentModel.DataAnnotations;

namespace ReservaHoteles_TPFinal.Models
{
    public class Habitacion
    {
        [Key]
        public int Id{ get; set; }
        [Required]
        public int numHabitacion { get; set; }
        [Required]
        public int capacidad { get; set; }
        [Required]
        public double costoPorDia { get; set; }
        [Required]
        public bool ocupada { get; set; }
    }
}
