using CCVLab.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CCVLab.Controllers
{
    public class PacienteController : Controller
    {
        private readonly ILogger<PacienteController> _logger;

        public PacienteController(ILogger<PacienteController> logger)
        {
            _logger = logger;
        }
        public IActionResult Listarpaciente()
        {
            return View();
        }

        public IActionResult Crearpaciente()
        {
            return View();
        }

        public IActionResult Detallepaciente()
        {
            return View();
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