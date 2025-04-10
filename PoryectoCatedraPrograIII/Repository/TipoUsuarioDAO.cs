using Microsoft.EntityFrameworkCore;
using PoryectoCatedraPrograIII.Data;
using PoryectoCatedraPrograIII.Models;

namespace PoryectoCatedraPrograIII.Repository
{
    public class TipoUsuarioDAO: ITipoUsuarioDAO
    {

        private readonly DBContext _context;

        public TipoUsuarioDAO(DBContext storeContext)
        {
            _context = storeContext;
        }

        public async Task<IEnumerable<TipoUsuario>> Get() => await _context.TipoUsuarios.ToListAsync();

        public async Task<TipoUsuario> GetById(int id) => await _context.TipoUsuarios.FindAsync(id);

        public async Task Add(TipoUsuario entity) => await _context.TipoUsuarios.AddAsync(entity);

        public void Update(TipoUsuario entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TipoUsuario entity) => _context.TipoUsuarios.Remove(entity);

        public async Task Save() => await _context.SaveChangesAsync();


    }
}
