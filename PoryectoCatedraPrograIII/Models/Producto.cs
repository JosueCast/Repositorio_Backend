using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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

        public int Stock { get; set; }

        [Required, MaxLength(100)]
        public string Categoria { get; set; }

        public string Foto { get; set; }


        [Required, MaxLength(50)]
        public string Sku { get; set; }

        public string Descripcion { get; set; }

        [Required, MaxLength(100)]
        public string Marca { get; set; }

        public bool Estado { get; set; } // Activo/Inactivo

        [ForeignKey("Tienda")]
        public int TiendaId { get; set; }
        public Tienda Tienda { get; set; }

        public List<Review> reviews { get; set; }

    }
}
