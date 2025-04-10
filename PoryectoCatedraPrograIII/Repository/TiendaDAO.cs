using Microsoft.EntityFrameworkCore;
using PoryectoCatedraPrograIII.Data;
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

        public async Task<Tienda> GetById(int id) => await _context.Tiendas.FindAsync(id);

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
