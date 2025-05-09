using System.ComponentModel.DataAnnotations;

namespace PoryectoCatedraPrograIII.DTO
{
    public class TiendaCreateDTO
    {
        [Required, MaxLength(150)]
        public string Nombre { get; set; }

        public string HorarioInicio { get; set; }

        public string HorarioSalida { get; set; }

        public string FotoFachada { get; set; }


        public string Slogan { get; set; }

        [Required]
        public string NumeroContacto { get; set; }

        public string FacebookContacto { get; set; }

        public string PaginaWeb { get; set; }

        public bool TieneEnvio { get; set; }

        [Required]
        public int idTipoTiendas { get; set; }

        // Agregado para vincular con el usuario propietario de la tienda
        [Required]
        public int UsuarioId { get; set; }
    }

}
