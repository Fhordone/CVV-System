using CCVLab.Models;
namespace CCVLab.Services
{
    public interface IService_API_Paciente
    {
        /*Administrar Pacientes*/
        Task<List<Paciente>> Lista();
        Task<Paciente> ObtenerPaciente(int ID);
        Task<bool> CreatePaciente(Paciente objeto);
        /*Funcionalidad de Editar la Cita*/
        Task<bool> UpdatePaciente (Paciente objeto);
    }
}
