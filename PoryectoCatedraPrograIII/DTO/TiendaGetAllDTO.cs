namespace PoryectoCatedraPrograIII.DTO
{
    public class TiendaGetAllDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string HorarioInicio { get; set; }
        public string HorarioSalida { get; set; }
        public string FotoFachada { get; set; }
        public string Slogan { get; set; }
        public string NumeroContacto { get; set; }
        public string? FacebookContacto { get; set; }
        public string? PaginaWeb { get; set; }
        public bool TieneEnvio { get; set; }

        public int TipoTiendaId { get; set; }           // Nuevo: el ID del tipo
        
        public string TipoTiendaNombre { get; set; } // Aquí irá el nombre del tipo
    }
}
