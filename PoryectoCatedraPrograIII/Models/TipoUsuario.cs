using System.ComponentModel.DataAnnotations;

namespace PoryectoCatedraPrograIII.Models
{
    public class TipoUsuario
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

    }
}
