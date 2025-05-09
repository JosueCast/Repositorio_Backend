using PoryectoCatedraPrograIII.Models;

namespace PoryectoCatedraPrograIII.Repository
{
    public interface IProductoDAO
    {
        Task<IEnumerable<Producto>> Get();
        Task<Producto> GetById(int id);
        Task<List<Producto>> GetByTiendaId(int tiendaId);
        Task<Tienda> GetTiendaById(int id);

        Task Add(Producto entity);
        Task Update(Producto entity);  
        void Delete(Producto entity);
        Task Save();
    }
}
