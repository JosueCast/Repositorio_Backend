using System.ComponentModel.DataAnnotations;

namespace PoryectoCatedraPrograIII.DTO
{
    public class ProductoUpdateDTO
    {
        [Required, MaxLength(150)]
        public string Nombre { get; set; }

        [Required]
        public decimal Precio { get; set; }

        public string Foto { get; set; }

        public string? Descripcion { get; set; }

        [Required, MaxLength(100)]
        public string? Marca { get; set; }

        public bool Estado { get; set; }

        [Required]
        public int TiendaId { get; set; }
    }
}
