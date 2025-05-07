using System.ComponentModel.DataAnnotations;

namespace PoryectoCatedraPrograIII.DTO
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
    public class UsuarioCreateDTO
    {
        [Required, MaxLength(100)]
        public string Nombre { get; set; }

        [Required, EmailAddress, MaxLength(150)]
        public string Correo { get; set; }

        [MinLengthIfNotNull(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
        public string? Contraseña { get; set; }

        public string FotoPerfil { get; set; }
        public string? Nit { get; set; }

        [Required]
        public int TipoUsuarioId { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
    }
}
