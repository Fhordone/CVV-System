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

        public async Task<List<Cita>> listarcitas()
        {
            List<Cita> listaCitas = new List<Cita>();

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(_baseurl);

                var response = await cliente.GetAsync("api/listarcitas");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    listaCitas = JsonConvert.DeserializeObject<List<Cita>>(jsonRespuesta);
                }
            }

            return listaCitas;
        }

        public async Task<Cita> obtenercita(int ID)
        {
            Cita cita = null; // Inicializa como null ya que no sabemos si encontraremos una cita

            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(_baseurl);

                    var response = await cliente.GetAsync($"api/obtenercita/{ID}"); // Corregido: agregué una barra antes del ID

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonRespuesta = await response.Content.ReadAsStringAsync();
                        cita = JsonConvert.DeserializeObject<Cita>(jsonRespuesta);
                    }
                }

                return cita;
            }
            catch (Exception ex)
            {
                // Manejar excepciones o registrarlas según sea necesario
                throw new Exception("Error al obtener la cita por ID", ex);
            }
        }
        public async Task<bool> createcita(Cita objeto)
        {
            bool respuesta = false;

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/createcita", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }
        public async Task<bool> updatecita(int ID, Cita objeto)
        {
            bool respuesta = false;
            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(_baseurl);

                    var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

                    var response = await cliente.PutAsync($"api/updatecita/{ID}", content); // 

                    if (response.IsSuccessStatusCode)
                    {
                        respuesta = true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones o registrarlas según sea necesario
                throw new Exception("Error al actualizar la cita", ex);
            }

            return respuesta;
        }
    }
}