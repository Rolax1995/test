using App_Libreria.Models;
using App_Libreria.Models.DB;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App_Libreria.Controllers
{
    public class HomeController : Controller
    {
        private readonly LibreriaContext _DBContext;

        public HomeController(LibreriaContext context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            //List<Estudiante> lista = _DBContext.Estudiantes.ToList();
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
    }
}