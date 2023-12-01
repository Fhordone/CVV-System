using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CCVLab.Models;
using CCVLab.Services;

namespace CCVLab.Controllers
{
    public class CitasController : Controller
    {
        private readonly IService_API _serviceApi;
        public CitasController (IService_API service_API)
        {
            _serviceApi = service_API;
        }
        // GET: LoginController
        public async Task<ActionResult> ListarCitas()
        {
            List<Cita> listarcitas = await _serviceApi.listarcitas();
            return View(listarcitas);
        }

        // GET: LoginController/Details/5
        public ActionResult CrearCitas(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult EditarCitas()
        {
            return View();
        }
        public ActionResult DetalleCitas()
        {
            return View();
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
