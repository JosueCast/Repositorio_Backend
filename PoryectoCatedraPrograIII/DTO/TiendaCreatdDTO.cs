using System.ComponentModel.DataAnnotations;

namespace PoryectoCatedraPrograIII.DTO
{
    public class TiendaCreateDTO
    {
        [Required, MaxLength(150)]
        public string Nombre { get; set; }

        public string HorarioInicio { get; set; }

        public string HoararioSalida { get; set; }

        public string FotoFachada { get; set; }

        [Required, MaxLength(100)]
        public string Categoria { get; set; }

        public string Slogan { get; set; }

        [Required]
        public string NumeroContacto { get; set; }

        public string FacebookContacto { get; set; }

        public string PaginaWeb { get; set; }

        public bool TieneEnvio { get; set; }

        [Required]
        public int idTipoTiendas { get; set; }
    }

}
