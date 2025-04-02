using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PoryectoCatedraPrograIII.Models
{
    public class Review
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

        [Required, Range(1, 5)]
        public int Calificacion { get; set; } // 1 a 5 estrellas

        public string Comentario { get; set; }

        public DateTime Fecha { get; set; } = DateTime.UtcNow;
    }
}
