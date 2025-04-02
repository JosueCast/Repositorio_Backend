using System.ComponentModel.DataAnnotations;

namespace PoryectoCatedraPrograIII.Models
{
    public class HistorialBusqueda
    {

        [Key]
        public int HistorialBusquedaId { get; set; }  // Clave primaria para HistorialBusqueda

        public int UsuarioId { get; set; }  // Relación con el usuario

        public string PalabraClave { get; set; }

        public DateTime FechaBusqueda { get; set; }

        // Relación con la tabla de Usuario (si tienes esa tabla definida)
        public virtual Usuario Usuario { get; set; }  // Esto puede ir si tienes la clase Usuario mapeada correctamente

    }
}
