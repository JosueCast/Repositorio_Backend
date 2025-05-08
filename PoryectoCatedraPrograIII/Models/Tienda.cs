using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoryectoCatedraPrograIII.Models
{
    public class Tienda
    {

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string HorarioInicio { get; set; }

        [MaxLength(50)]
        public string HorarioSalida { get; set; }

        [MaxLength(255)]
        public string FotoFachada { get; set; }

       //se elemino la categoria de tienda

        [MaxLength(200)]
        public string Slogan { get; set; }

        [Required, MaxLength(20)]
        public string NumeroContacto { get; set; }

        [MaxLength(150)]
        public string FacebookContacto { get; set; }

        [MaxLength(150)]
        public string PaginaWeb { get; set; }

        public bool TieneEnvio { get; set; }

        // Relación uno a muchos (una tienda puede tener muchos productos)
        public List<Producto> Productos { get; set; } = new List<Producto>();

        [Required]
        public int idTipoTiendas { get; set; }

        [ForeignKey("idTipoTiendas")]
        public TipoTienda TipoTiendas { get; set; }


    }
}
