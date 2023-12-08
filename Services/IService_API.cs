using CCVLab.Models;

namespace CCVLab.Services
{
    public interface IService_API
    {
        Task<List<Cita>> Lista();
        Task<Cita> ObtenerCita(int ID);
        Task<bool> CreateCita(Cita objeto);
        Task<bool> UpdateCita (Cita objeto);
    }
}

