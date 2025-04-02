using System.ComponentModel.DataAnnotations;

namespace PoryectoCatedraPrograIII.Models
{
    public class Promocion
    {
        [Key]
        public int PromocionId { get; set; }  // Definimos la clave primaria

        [Required]
        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public decimal PrecioOriginal { get; set; }

        public decimal PrecioDescuento { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public bool Activo { get; set; }  // Indica si la promoción está activa

    }
}
