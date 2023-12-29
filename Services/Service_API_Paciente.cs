using CCVLab.Models;
using CCVLab.Services;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
namespace CCVLab
{
    public class Service_API_Paciente : IService_API_Paciente
    {
        private static string _baseUrlPaciente;

        public Service_API_Paciente()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrlPaciente = builder.GetSection("ApiSettings:baseUrlPaciente").Value;
        }
        public async Task<List<Paciente>> Lista()
        {
            List<Paciente> lista = new List<Paciente>();
            /*Falta Autenticación*/
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrlPaciente);
            var response = await cliente.GetAsync("api/ListarPacientes");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApiPaciente>(json_respuesta);
                lista = resultado.lista;
            }
            return lista;
        }
        public async Task<Paciente> ObtenerPaciente(int ID)
        {
            Paciente objeto = new Paciente();
            /*Falta Autenticación*/
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrlPaciente);
            var response = await cliente.GetAsync($"api/ObtenerPaciente/{ID}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApiPaciente>(json_respuesta);
                objeto = resultado.objeto;
            }
            return objeto;
        }
        public async Task<bool> CreatePaciente(Paciente objeto)
        {
            bool respuesta = false;
            /*Falta Autenticación*/
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrlPaciente);

            var content = new StringContent(JsonConvert.SerializeObject(objeto),Encoding.UTF8,"application/json");

            var response = await cliente.PostAsync("api/CreatePaciente",content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }
        public async Task<bool> UpdatePaciente(Paciente objeto)
        {
            bool respuesta = false;
            /*Falta Autenticación*/
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrlPaciente);

            var content = new StringContent(JsonConvert.SerializeObject(objeto),Encoding.UTF8,"application/json");

            var response = await cliente.PutAsync("api/updatepaciente",content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }
    }
}