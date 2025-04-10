using PoryectoCatedraPrograIII.Models;

namespace PoryectoCatedraPrograIII.Repository
{
    public interface ITipoUsuarioDAO
    {
        Task<IEnumerable<TipoUsuario>> Get();
        Task<TipoUsuario> GetById(int id);
        Task Add(TipoUsuario entity);
        void Update(TipoUsuario entity);
        void Delete(TipoUsuario entity);
        Task Save();
    }
}
