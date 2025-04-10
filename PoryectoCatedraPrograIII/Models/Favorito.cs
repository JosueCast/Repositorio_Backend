using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PoryectoCatedraPrograIII.Models
{
    public class Favorito
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [ForeignKey("Producto")]
        public int? ProductoId { get; set; }
        public Producto Producto { get; set; }

        [ForeignKey("Tienda")]
        public int? TiendaId { get; set; }
        public Tienda Tienda { get; set; }

        [Required]
        public string Tipo { get; set; } // "Favorito" o "Me Interesa"

    }
}
