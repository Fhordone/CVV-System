using CCVLab.Models;
using CCVLab.Services;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
namespace CCVLab
{
    public class Service_API_Examen : IService_API_Examen
    {
        private static string _baseUrlExamen;

        public Service_API_Examen()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrlExamen = builder.GetSection("ApiSettings:baseUrlExamen").Value;
            
        }
        public async Task<List<Examen>> Lista()
        {
            List<Examen> lista = new List<Examen>();
            /*Falta Autenticación*/
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrlExamen);
            var response = await cliente.GetAsync("api/ListarExamen");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApiExamen>(json_respuesta);
                lista = resultado.lista;
            }
            return lista;
        }
    }
}