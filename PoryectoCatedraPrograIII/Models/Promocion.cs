using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoryectoCatedraPrograIII.Models
{
    public class Promocion
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Nombre { get; set; }

        public decimal Descuento { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        // Relación con Tienda
        public int TiendaId { get; set; }
        public Tienda Tienda { get; set; }

    }
}
