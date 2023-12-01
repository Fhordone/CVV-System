using CCVLab.Models;

namespace CCVLab.Services
{
    public interface IService_API
    {
        Task<List<Cita>> listarcitas();
        Task<Cita> obtenercita(int ID);
        Task<bool> createcita(Cita objeto);
        Task<bool> updatecita (int ID,Cita objeto);
    }
}

