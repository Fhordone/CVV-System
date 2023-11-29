using CCVLab.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CCVLab.Controllers
{
    public class PruebaController : Controller
    {
        private readonly ILogger<PruebaController> _logger;

        public PruebaController(ILogger<PruebaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Prueba()
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