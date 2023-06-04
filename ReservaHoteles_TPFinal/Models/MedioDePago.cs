using System.ComponentModel.DataAnnotations;

namespace ReservaHoteles_TPFinal.Models
{
    public class MedioDePago
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string nombre { get; set; }
    }
}
