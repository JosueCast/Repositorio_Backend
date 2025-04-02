using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using PoryectoCatedraPrograIII.Models;

namespace PoryectoCatedraPrograIII.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Favorito> Favoritos { get; set; }
        public DbSet<EventoNegocio> EventosNegocios { get; set; }
        public DbSet<TipoUsuario> TipoUsuarios { get; set; } // Agregamos esta línea



    }
}

