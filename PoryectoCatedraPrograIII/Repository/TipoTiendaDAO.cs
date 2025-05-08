using Microsoft.EntityFrameworkCore;
using PoryectoCatedraPrograIII.Data;
using PoryectoCatedraPrograIII.Models;

namespace PoryectoCatedraPrograIII.Repository
{
    public class TipoTiendaDAO: ITipoTiendaDAO
    {
        private readonly DBContext _context;

        public TipoTiendaDAO(DBContext storeContext)
        {
            _context = storeContext;
        }

        public async Task<IEnumerable<TipoTienda>> Get() => await _context.TipoTiendas.ToListAsync();

        public async Task<TipoTienda> GetById(int id) => await _context.TipoTiendas.FindAsync(id);

        public async Task<TipoTienda?> GetByName(string name)
        {
            return await _context.TipoTiendas
                .Where(t => t.Nombre.ToLower() == name.ToLower())
                .FirstOrDefaultAsync();
        }

        public async Task Add(TipoTienda entity) => await _context.TipoTiendas.AddAsync(entity);

        public void Update(TipoTienda entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TipoTienda entity) => _context.TipoTiendas.Remove(entity);

        public async Task Save() => await _context.SaveChangesAsync();
    }
}
