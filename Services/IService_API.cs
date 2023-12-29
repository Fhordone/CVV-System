using CCVLab.Models;

namespace CCVLab.Services
{
    public interface IService_API
    {
        /*Lista las Citas*/
        Task<List<ViewCita>> Lista();
        /*Redirecciona a la vista correspondiente (Crear o Editar según el ID)*/
        Task<Cita> ObtenerCita(int ID);
        /*Funcionalidad de Crear la Cita*/
        Task<bool> CreateCita(CreateCitaModel obj);
        /*Funcionalidad de Editar la Cita*/
        Task<bool> UpdateCita (CreateCitaModel obj);

    }
}

