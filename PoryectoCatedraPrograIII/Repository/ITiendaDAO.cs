using PoryectoCatedraPrograIII.Models;

namespace PoryectoCatedraPrograIII.Repository
{
    public interface ITiendaDAO
    {

        Task<IEnumerable<Tienda>> Get();
        Task<Tienda> GetById(int id);
        Task Add(Tienda entity);
        void Update(Tienda entity);
        void Delete(Tienda entity);
        Task Save();

    }
}
