using PoryectoCatedraPrograIII.Models;

namespace PoryectoCatedraPrograIII.Repository
{
    public interface IUsuarioDAO
    {

        Task<IEnumerable<Usuario>> Get();
        Task<Usuario> GetById(int id);
        Task Add(Usuario entity);
        void Update(Usuario entity);
        void Delete(Usuario entity);
        Task Save();


    }
}
