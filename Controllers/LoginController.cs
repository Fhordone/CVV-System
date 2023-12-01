using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using CCVLab.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CCVLab.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace CCVLab.Controllers
{
    public class LoginController : Controller
    {
        private readonly DatabaseContext _context;
        //private readonly DA_Login _dalogin;
        private readonly ILogger<HomeController> _logger;
        public LoginController(ILogger<HomeController> logger,
         DatabaseContext context)
        {
            _logger = logger;
            _context = context;
           // _dalogin = dalogin;
        }
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(Usuario model)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _context.Usuarios
            .Include(u => u.UsuarioRol)
            .ThenInclude(ur => ur.Rol)
            .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

                if (usuario != null)
                {
                    // Autenticación exitosa
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, usuario.Nombres),
                        new Claim(ClaimTypes.Surname, usuario.Apellidos),
                        new Claim(ClaimTypes.NameIdentifier, usuario.ID.ToString()),
                        new Claim("Correo", usuario.Email)
                    };

                    foreach (var usuarioRol in usuario.UsuarioRol)
                    {
                        if(usuarioRol.Rol != null)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, usuarioRol.Rol.Nombre));
                        }
                    }

                    var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                    return RedirectToAction("ListarCitas", "Citas");
                }

                ModelState.AddModelError(string.Empty, "Email o clave incorrectos.");
            }

            return View(model);
        }

        // GET: LoginController/Details/5
        public ActionResult Pruebas(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
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
