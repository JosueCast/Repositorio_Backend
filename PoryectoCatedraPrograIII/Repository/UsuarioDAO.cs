using Microsoft.EntityFrameworkCore;
using PoryectoCatedraPrograIII.Data;
using PoryectoCatedraPrograIII.Models;

namespace PoryectoCatedraPrograIII.Repository
{
    public class UsuarioDAO : IUsuarioDAO
    {

        private readonly DBContext _context;

        public UsuarioDAO(DBContext storeContext)
        {
            _context = storeContext;
        }

        public async Task<IEnumerable<Usuario>> Get() => await _context.Usuarios.ToListAsync();

        public async Task<Usuario> GetById(int id) => await _context.Usuarios.FindAsync(id);
        public async Task<Usuario?> GetByEmail(string email)
        {
            return await _context.Usuarios
                .Where(u => u.Correo == email)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> NitExisteAsync(string nit)
        {
            return await _context.Usuarios.AnyAsync(u => u.nit == nit);
        }
        public async Task<Usuario?> GetByNit(string nit)
        {
            return await _context.Usuarios
                .Where(u => u.nit == nit)
                .FirstOrDefaultAsync();
        }

        public async Task Add(Usuario entity) => await _context.Usuarios.AddAsync(entity);

        public void Update(Usuario entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Usuario entity) => _context.Usuarios.Remove(entity);

        public async Task Save() => await _context.SaveChangesAsync();

    }
}
