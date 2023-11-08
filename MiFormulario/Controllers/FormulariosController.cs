using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using MiFormulario.Models;
using MiFormulario.Services;

namespace MiFormulario.Controllers
{
    public class FormulariosController : Controller
    {
        private readonly IEmailService _emailService;

        public FormulariosController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Formulario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviarInformacion(EmailViewModelExtenso model)
        {

            TempData["EmailT"] = model.Email;
            TempData["ComentarioT"] = model.Mensaje;

            var result = _emailService.ProcesarSolicitud(model);

            if (!result)
            {
                TempData["EmailT"] = null;
                TempData["EmailError"] = "Ocurrió un error";
            }
            return View("Formulario", model);
        }
    }
}
