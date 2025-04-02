using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PoryectoCatedraPrograIII.Models
{
    public class EventoNegocio
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Evento")]
        public int EventoId { get; set; }
        public Evento Evento { get; set; }

        [ForeignKey("Tienda")]
        public int TiendaId { get; set; }
        public Tienda Tienda { get; set; }

    }
}
