using System.ComponentModel.DataAnnotations;

namespace PoryectoCatedraPrograIII.DTO
{
    public class TiendaUpdateDTO
    {
        [Required]
        public int Id { get; set; } // Importante para saber qué tienda se actualizará

        [Required, MaxLength(150)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string HorarioInicio { get; set; }

        [MaxLength(50)]
        public string HoararioSalida { get; set; }

        [MaxLength(255)]
        public string FotoFachada { get; set; }

        [Required, MaxLength(100)]
        public string Categoria { get; set; }

        [MaxLength(200)]
        public string Slogan { get; set; }

        [Required, MaxLength(20)]
        public string NumeroContacto { get; set; }

        [MaxLength(150)]
        public string FacebookContacto { get; set; }

        [MaxLength(150)]
        public string PaginaWeb { get; set; }

        public bool TieneEnvio { get; set; }

        [Required]
        public int idTipoTiendas { get; set; } // Clave foránea
    }

}
