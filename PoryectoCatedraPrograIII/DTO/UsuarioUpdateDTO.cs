using System.ComponentModel.DataAnnotations;

namespace PoryectoCatedraPrograIII.DTO
{
    public class UsuarioUpdateDTO
    {

        [Required]
        public string Nombre { get; set; }

        [Required, EmailAddress]
        public string Correo { get; set; }

        public string? Contraseña { get; set; } // Omitir si no se cambia

        public string FotoPerfil { get; set; }

        public string Nit { get; set; }
    }
}
