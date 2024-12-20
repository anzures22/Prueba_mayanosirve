using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Prueba_maya.Models;

namespace Prueba_maya.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Dashboard()
        {
            var idRol = HttpContext.Session.GetInt32("IdRol");

            if (idRol == 1) // Administrador
            {
                return View("DashboardAdmin");
            }
            else if (idRol == 3) // Cliente
            {
                return View("DashboardCliente");
            }

            return RedirectToAction("Index");
        }

    }
}
