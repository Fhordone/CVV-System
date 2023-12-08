using CCVLab.Models;
using CCVLab.Services;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
namespace CCVLab
{
    public class Service_API : IService_API
    {
        private static string _baseurl;

        public Service_API()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseurl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

        public async Task<List<Cita>> Lista()
        {
            List<Cita> lista = new List<Cita>();
            /*Falta Autenticación*/
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync("api/ListarCita");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);
                lista = resultado.lista;
            }
            return lista;
        }

        public async Task<Cita> ObtenerCita(int ID)
        {
            Cita objeto = new Cita();
            /*Falta Autenticación*/
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/ObtenerCita/{ID}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);
                objeto = resultado.objeto;
            }
            return objeto;
        }
        public async Task<bool> CreateCita(Cita objeto)
        {
            bool respuesta = false;
            /*Falta Autenticación*/
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(objeto),Encoding.UTF8,"application/json");

            var response = await cliente.PostAsync("api/CreateCita",content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }
        public async Task<bool> UpdateCita(Cita objeto)
        {
            bool respuesta = false;
            /*Falta Autenticación*/
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(objeto),Encoding.UTF8,"application/json");

            var response = await cliente.PostAsync("api/updatecita",content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }
    }
}