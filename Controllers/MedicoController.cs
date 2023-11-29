using CCVLab.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CCVLab.Controllers
{
    public class MedicoController : Controller
    {
        private readonly ILogger<MedicoController> _logger;

        public MedicoController(ILogger<MedicoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Crearmedico()
        {
            return View();
        }

        public IActionResult Editarmedico()
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