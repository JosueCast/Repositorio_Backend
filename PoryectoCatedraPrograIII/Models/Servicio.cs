using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PoryectoCatedraPrograIII.Models
{
    public class Servicio
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string TipoMateriales { get; set; }

        public int TiempoEstimado { get; set; }

        [Required, MaxLength(100)]
        public string Categoria { get; set; }

        public string AreaServicio { get; set; }

        [ForeignKey("Tienda")]
        public int TiendaId { get; set; }
        public Tienda Tienda { get; set; }
    }
}
