using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CCVLab.Models;
using System.Security.Claims;
using CCVLab.Data;
using CCVLab.Services;

namespace CCVLab.Controllers
{
    public class CitasController : Controller
    {
        private readonly IService_API _serviceApi;
        private readonly IService_API_Paciente _serviceApiPaciente;
        private readonly IService_API_Examen _serviceApiExamen;

        public CitasController(IService_API service_API, IService_API_Paciente service_API_Paciente, IService_API_Examen service_API_Examen)
        {
            _serviceApi = service_API;
            _serviceApiPaciente = service_API_Paciente;
            _serviceApiExamen = service_API_Examen;
        }
        public async Task<ActionResult> ListarCitas()
        {
            List<ViewCita> lista = await _serviceApi.Lista();
            return View(lista);
        }
        public async Task<ActionResult> CrearCitas()
        {
            var listaPacientes = await _serviceApiPaciente.Lista();
            var listaExamenes = await _serviceApiExamen.Lista();

            ViewBag.ListaPacientes = listaPacientes;
            ViewBag.listaExamenes = listaExamenes;

            return View();
        }
        public async Task<ActionResult> Cita(int ID)
        {
            Cita modelo_cita = new Cita();

            ViewBag.Accion = "Nueva Cita";

            if (ID != 0)
            {
                modelo_cita = await _serviceApi.ObtenerCita(ID);
                ViewBag.Accion = "Editar Cita";
            }
            return View(modelo_cita);
        }

        public async Task<ActionResult> DetalleCitas(int ID)
        {
            Cita modelo_cita = new Cita();/*Se debe traer al modelo correspondiente*/

            ViewBag.Accion = "Nueva Cita";

            if (ID != 0)
            {
                modelo_cita = await _serviceApi.ObtenerCita(ID);
                ViewBag.Accion = "Detalle de la Cita";
            }
            return View(modelo_cita);
        }

        [HttpPost]
        public async Task<ActionResult> GuardarCita(CreateCitaModel obj_cita)
        {
            bool respuesta;

            if (obj_cita.ID == 0)
            {
                var examenesSeleccionadosValues = Request.Form["Examenes"];
                if (examenesSeleccionadosValues.Count > 0)
                {
                    obj_cita.Examenes = examenesSeleccionadosValues.Select(int.Parse).ToList();
                }

                respuesta = await _serviceApi.CreateCita(obj_cita);
            }
            else
            {
                respuesta = await _serviceApi.UpdateCita(obj_cita);
            }

            if (respuesta)
                return RedirectToAction("ListarCitas");
            else
                return NoContent();
        }
    }
}
