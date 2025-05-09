using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PoryectoCatedraPrograIII.Models
{
    public class Producto
    {

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Nombre { get; set; }

        [Required]
        public decimal Precio { get; set; }

        public string Foto { get; set; }

        public string? Descripcion { get; set; }

        [Required, MaxLength(100)]
        public string? Marca { get; set; }

        public bool Estado { get; set; } // Activo/Inactivo

        [ForeignKey("Tienda")]
        public int TiendaId { get; set; }
        [JsonIgnore]
        public Tienda Tienda { get; set; }

        public List<Review> Reviews { get; set; } // Relación con las reseñas


    }
}
