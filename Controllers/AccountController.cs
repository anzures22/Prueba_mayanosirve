using Microsoft.AspNetCore.Mvc;
using Prueba_maya.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

public class AccountController : Controller
{
    private readonly TiendaContext _context;

    public AccountController(TiendaContext context)
    {
        _context = context;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string nombreUsuario, string contrasena)
    {
        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario && u.Contrasena == contrasena);

        if (usuario != null)
        {
            // Almacena temporalmente el rol y usuario en la sesión
            HttpContext.Session.SetInt32("IdRol", usuario.IdRol ?? 0);

            HttpContext.Session.SetString("NombreUsuario", usuario.NombreUsuario);

            return RedirectToAction("Dashboard", "Home");
        }
        else
        {
            ViewBag.Error = "Credenciales incorrectas";
            return View();
        }
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
}
