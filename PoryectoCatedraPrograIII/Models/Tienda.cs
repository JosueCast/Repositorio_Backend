using System.ComponentModel.DataAnnotations;

namespace PoryectoCatedraPrograIII.Models
{
    public class Tienda
    {

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Nombre { get; set; }

        public string HorarioInicio  { get; set; }
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

        public List<Producto> Productos { get; set; }

        public int idTipoTiendas { get; set; }
        public TipoTienda TipoTiendas { get; set; }


    }
}
