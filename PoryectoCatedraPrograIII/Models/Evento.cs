using System.ComponentModel.DataAnnotations;

namespace PoryectoCatedraPrograIII.Models
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Nombre { get; set; }

        public string Tipo { get; set; }

        public string Direccion { get; set; }

        public DateTime HoraInicio { get; set; }

        public DateTime HoraFinal { get; set; }

        public decimal PrecioEntrada { get; set; }

        public string FotoLugar { get; set; }

        public string Descripcion { get; set; }

        public List<EventoNegocio> NegociosParticipantes { get; set; }

    }
}
