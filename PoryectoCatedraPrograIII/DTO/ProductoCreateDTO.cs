using System.ComponentModel.DataAnnotations;

namespace PoryectoCatedraPrograIII.DTO
{
    public class ProductoCreateDTO
    {


        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Foto { get; set; }
        public string? Descripcion { get; set; }
        public string Marca { get; set; }
        public bool Estado { get; set; }
        public int TiendaId { get; set; }


    }
}
