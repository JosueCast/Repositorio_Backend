using PoryectoCatedraPrograIII.Models;

namespace PoryectoCatedraPrograIII.Repository
{
    public interface ITipoTiendaDAO
    {
        Task<IEnumerable<TipoTienda>> Get();
        Task<TipoTienda> GetById(int id);
        Task Add(TipoTienda entity);
        void Update(TipoTienda entity);
        void Delete(TipoTienda entity);
        Task Save();
    }
}
