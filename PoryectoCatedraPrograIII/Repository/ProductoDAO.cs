using Microsoft.EntityFrameworkCore;
using PoryectoCatedraPrograIII.Data;
using PoryectoCatedraPrograIII.Models;

namespace PoryectoCatedraPrograIII.Repository
{
    public class ProductoDAO:IProductoDAO
    {

        private readonly DBContext _context;

        public ProductoDAO(DBContext storeContext)
        {
            _context = storeContext;
        }

        public async Task<IEnumerable<Producto>> Get() => await _context.Productos.ToListAsync();

        public async Task<Producto> GetById(int id) => await _context.Productos.FindAsync(id);

        public async Task<List<Producto>> GetByTiendaId(int tiendaId)
        {
            return await _context.Productos
                .Where(p => p.TiendaId == tiendaId)
                .ToListAsync();
        }

        public async Task Add(Producto entity) => await _context.Productos.AddAsync(entity);

        public async Task Update(Producto producto)
        {
            _context.Productos.Update(producto);
            await Task.CompletedTask; // Esto permite que el método sea awaitable
        }

        public void Delete(Producto entity) => _context.Productos.Remove(entity);

        public async Task Save() => await _context.SaveChangesAsync();

        public async Task<Tienda> GetTiendaById(int tiendaId)
        {
            return await _context.Tiendas.FirstOrDefaultAsync(t => t.Id == tiendaId);
        }

    }
}
