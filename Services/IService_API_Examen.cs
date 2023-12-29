using CCVLab.Models;

namespace CCVLab.Services
{
    public interface IService_API_Examen
    {
        /*Lista los examenes*/
        Task<List<Examen>> Lista();
        /*Redirecciona a la vista correspondiente (Crear o Editar según el ID)*/
    }
}