using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CCVLab.Models;
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
            List<Cita> listarcitas = await _serviceApi.listarcitas();
            return View(listarcitas);
        }
        public ActionResult CrearCitas()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateCitas(Cita obj_cita)
        {
            bool respuesta;
            respuesta = await _serviceApi.createcita(obj_cita);
            return RedirectToAction("ListarCitas");
        }
        public ActionResult DetalleCitas()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> EditarCitas(int ID, Cita obj_cita)
        {
            try
            {
                bool respuesta = await _serviceApi.updatecita(ID, obj_cita);

                if (respuesta)
                {
                    return RedirectToAction("ListarCitas");
                }
                else
                {
                    // Puedes manejar el caso en que la actualización no fue exitosa
                    // Podrías redirigir a una página de error o realizar alguna otra acción
                    // según la lógica de tu aplicación.
                    return RedirectToAction("Error");
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones o registrarlas según sea necesario
                return RedirectToAction("Error");
            }
        }
        public async Task<ActionResult> ObtenerCitas(int ID)
        {
            try
            {
                Cita cita = await _serviceApi.obtenercita(ID);
                if (cita != null)
                {
                    // Puedes hacer algo con la cita, como pasarla a la vista
                    return RedirectToAction("DetalleCitas");
                }
                else
                {
                    // Puedes redirigir a una página de error o manejar de otra manera
                    return RedirectToAction("Error");
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones o registrarlas según sea necesario
                return RedirectToAction("Error");
            }

        }
        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
