using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        [Required, MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
        public string Contraseña { get; set; }

        public string FotoPerfil { get; set; } // Opcional, puede ser nulo

       

        [Required]
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;

        [Required]
        public int TipoUsuarioId { get; set; } // Clave foránea obligatoria

        [JsonIgnore]
        [ForeignKey("TipoUsuarioId")]
        public TipoUsuario TipoUsuario { get; set; } // Relación con TipoUsuario

        // Colección de reseñas relacionadas con el usuario
        public List<Review> reviews { get; set; } = new List<Review>();

        // Colección de favoritos asociados con el usuario
        public List<Favorito> Favoritos { get; set; } = new List<Favorito>();
    }

}
