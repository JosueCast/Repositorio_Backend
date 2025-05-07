using PoryectoCatedraPrograIII.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PoryectoCatedraPrograIII.Models
{

    public class MinLengthIfNotNullAttribute : ValidationAttribute
    {
        private readonly int _minLength;

        public MinLengthIfNotNullAttribute(int minLength)
        {
            _minLength = minLength;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success; // Válido si es nulo o vacío
            }

            if (value.ToString().Length < _minLength)
            {
                return new ValidationResult(ErrorMessage ?? $"El campo debe tener al menos {_minLength} caracteres.");
            }

            return ValidationResult.Success;
        }
    }

    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; }

        [Required, EmailAddress, MaxLength(150)]
        public string Correo { get; set; }

        [MinLengthIfNotNull(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
        public string? Contrasena { get; set; }

        public string FotoPerfil { get; set; } // Opcional, puede ser nulo

        public string? nit { get; set; }

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
