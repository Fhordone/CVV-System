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
        
        public CitasController(IService_API service_API)
        {
            _serviceApi = service_API;
            
        }
        // GET: LoginController
        public async Task<ActionResult> ListarCitas()
        {
            List<Cita> lista = await _serviceApi.Lista();
            return View(lista);
        }
        public async Task<ActionResult> Cita(int ID)
        {
            Cita modelo_cita = new Cita();/*Se debe traer al modelo correspondiente*/

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

        public ActionResult CrearCitas()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> GuardarCita(Cita obj_cita)
        {
            bool respuesta;

            if(obj_cita.ID == 0){
                respuesta = await _serviceApi.CreateCita(obj_cita);
            }
            else {
                respuesta = await _serviceApi.UpdateCita(obj_cita);
            }
            if (respuesta)
            return RedirectToAction("ListarCitas");
            else
            return NoContent();   
        }
    }
}
