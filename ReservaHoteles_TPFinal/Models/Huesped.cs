using System.ComponentModel.DataAnnotations;

namespace ReservaHoteles_TPFinal.Models
{
    public class Huesped
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string apellido { get; set; }

        [Required]
        public int dni { get; set; }

        [Required]
        public int nroHabitacion { get; set; }

    }
}
