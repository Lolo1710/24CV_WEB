using Microsoft.AspNetCore.Mvc;
using MiFormulario.Models;

namespace MiFormulario.Controllers
{
    public class EjemplosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            Persona persona = new Persona();
            persona.Nombre = "Alfredo";
            persona.Apellidos = "Casanova";
            persona.FechaNacimiento = new DateTime(1999, 10, 26);

            return View(persona);
        }
    }
}
