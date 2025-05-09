using Microsoft.EntityFrameworkCore;
using PoryectoCatedraPrograIII.Data;
using PoryectoCatedraPrograIII.DTO;
using PoryectoCatedraPrograIII.Models;

namespace PoryectoCatedraPrograIII.Repository
{
    public class TiendaDAO: ITiendaDAO
    {

        private readonly DBContext _context;

        public TiendaDAO(DBContext storeContext)
        {
            _context = storeContext;
        }


        public async Task<IEnumerable<Tienda>> Get() => await _context.Tiendas.ToListAsync();
        public async Task<IEnumerable<TiendaGetAllDTO>> GetAll()
        {
            return await _context.Tiendas
                .Include(t => t.TipoTiendas)
                .Select(t => new TiendaGetAllDTO
                {
                    Id = t.Id,
                    Nombre = t.Nombre,
                    HorarioInicio = t.HorarioInicio,
                    HorarioSalida = t.HorarioSalida,
                    FotoFachada = t.FotoFachada,
                    Slogan = t.Slogan,
                    NumeroContacto = t.NumeroContacto,
                    FacebookContacto = t.FacebookContacto,
                    PaginaWeb = t.PaginaWeb,
                    TieneEnvio = t.TieneEnvio,
                    TipoTiendaId = t.idTipoTiendas,                 // ID del tipo
                    TipoTiendaNombre = t.TipoTiendas.Nombre
                })
                .ToListAsync();
        }



        public async Task<Tienda> GetById(int id) => await _context.Tiendas.FindAsync(id);

        public async Task<Tienda?> GetByName(string name)
        {
            return await _context.Tiendas
                .Where(t => t.Nombre.ToLower() == name.ToLower())
                .FirstOrDefaultAsync();
        }

        public async Task Add(Tienda entity) => await _context.Tiendas.AddAsync(entity);

        public void Update(Tienda entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Tienda entity) => _context.Tiendas.Remove(entity);

        public async Task Save() => await _context.SaveChangesAsync();




    }
}
