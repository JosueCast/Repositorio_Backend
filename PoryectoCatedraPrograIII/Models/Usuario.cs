using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoryectoCatedraPrograIII.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; }

        [Required, EmailAddress, MaxLength(150)]
        public string Correo { get; set; }

        [Required]
        public string Contraseña { get; set; }

        public string FotoPerfil { get; set; }

        [Required]
        public string MetodoRegistro { get; set; } // Correo o Google

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;

        public int TipoUsuarioId { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        public List<Review> reviews { get; set; }
        public List<Favorito> Favoritos { get; set; }
        public List<HistorialBusqueda> HistorialBusquedas { get; set; }
    }
}
