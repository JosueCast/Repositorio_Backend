using PoryectoCatedraPrograIII.Models;

namespace PoryectoCatedraPrograIII.Repository
{
    public interface IUsuarioDAO
    {

        Task<IEnumerable<Usuario>> Get();
        Task<Usuario> GetById(int id);
        Task<Usuario> GetByEmail(string email);
        Task<Usuario> GetByNit(string nit);

        Task Add(Usuario entity);
        void Update(Usuario entity);
        void Delete(Usuario entity);
        Task Save();


    }
}

