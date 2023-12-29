using CCVLab.Models;
using CCVLab.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CCVLab.Controllers
{
    public class PacienteController : Controller
    {
        private readonly IService_API_Paciente _serviceApi;

        public PacienteController(IService_API_Paciente service_API)
        {
            _serviceApi = service_API;

        }
        public async Task<ActionResult> ListarPacientes(string dni = "")
        {
            List<Paciente> lista = await _serviceApi.Lista();

            if (!string.IsNullOrEmpty(dni))
            {
                lista = lista.Where(p => p.Nro_DNI.Contains(dni)).ToList();
            }

            return View(lista);
        }
        public async Task<ActionResult> BuscarPaciente(string dni)
        {
            List<Paciente> lista = await _serviceApi.Lista();

            if (!string.IsNullOrEmpty(dni))
            {
                lista = lista.Where(p => p.Nro_DNI.Contains(dni)).ToList();
            }

            return View("ListarPacientes", lista);
        }
        public IActionResult Crearpaciente()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreatePaciente(Paciente obj_paciente)
        {
            bool respuesta;

            Console.WriteLine("El modelo fue tomado correctamente.");
            respuesta = await _serviceApi.CreatePaciente(obj_paciente);

            if (respuesta)
            {
                return RedirectToAction("ListarPacientes");
            }
            else
            {
                return NoContent();
            }
        }
        public async Task<ActionResult> Form_Paciente(int ID)
        {
            Paciente modelo_paciente = new Paciente();/*Se debe traer al modelo correspondiente*/

            ViewBag.Accion = "Nuevo Paciente";

            if (ID != 0)
            {
                ViewBag.Accion = "Editar Paciente";
                modelo_paciente = await _serviceApi.ObtenerPaciente(ID);
            }
            return View(modelo_paciente);
        }
        [HttpPost]
        public async Task<ActionResult> GuardarPaciente(Paciente obj_paciente)
        {
            bool respuesta;

            Console.WriteLine("Se reconoció que el ID es distinto a 0.");
            respuesta = await _serviceApi.UpdatePaciente(obj_paciente);

            if (respuesta)
            {
                Console.WriteLine("Funcionó Correctamente.");
                return RedirectToAction("ListarPacientes");
            }
            else
            {
                Console.WriteLine("No funcionó :/.");
                return NoContent();
            }
        }
        public async Task<ActionResult> Detallepaciente(int ID)
        {
            Paciente modelo_paciente = new Paciente();/*Se debe traer al modelo correspondiente*/

            ViewBag.Accion = "Nuevo Paciente";

            if (ID != 0)
            {
                ViewBag.Accion = "Editar Paciente";
                modelo_paciente = await _serviceApi.ObtenerPaciente(ID);
            }
            return View(modelo_paciente);
        }
        public IActionResult Editarpaciente()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}