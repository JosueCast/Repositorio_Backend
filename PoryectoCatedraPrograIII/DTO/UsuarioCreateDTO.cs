using System.ComponentModel.DataAnnotations;

namespace PoryectoCatedraPrograIII.DTO
{
    public class UsuarioCreateDTO
    {
        [Required, MaxLength(100)]
        public string Nombre { get; set; }

        [Required, EmailAddress, MaxLength(150)]
        public string Correo { get; set; }

        [Required, MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
        public string Contraseña { get; set; }

        public string FotoPerfil { get; set; }

        [Required]
        public int TipoUsuarioId { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
    }
}
