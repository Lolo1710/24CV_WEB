using Microsoft.AspNetCore.Mvc;
using MiFormulario.Models;
using System.Net.Mail;
using System.Net;
using MiFormulario.Services;

namespace MiFormulario.Controllers
{
    public class ContactoController : Controller
    {
        private readonly IEmailService _emailSenderService;

        public ContactoController(IEmailService emailSenderService)
        {
            _emailSenderService = emailSenderService;
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
        public IActionResult EnviarCorreo(string email, string comentarios)
        {
            TempData["Email"] = email;
            TempData["Comentario"] = comentarios;

            SendEmail(email, comentarios);

            return View("Index","Contacto");
        }

        [HttpPost]
        public IActionResult EnviarInformacion(EmailViewModel model)
        {
            TempData["Email"] = model.Email;
            TempData["Comentario"] = model.Comentario;
            //SendMail(model.Email);

            var result = _emailSenderService.SendEmail(model.Email);

            if (!result)
            {
                TempData["EmailT"] = null;
                TempData["EmailError"] = "Ocurrió un error";
            }
            return View("Formulario", model);
        }

        public bool SendEmail(string email, string comentario)
        {
            MailMessage mail = new MailMessage();

            SmtpClient smtp = new SmtpClient("mail.ulatransfers.com", 465);

            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("info@ulatransfers.com", "LOLOlolo10.");

            mail.From = new MailAddress("info@ulatransfers.com", "Ula Transfers");
            mail.To.Add(email);
            mail.Subject = "Notificacion de contacto.";
            mail.IsBodyHtml = true;
            mail.Body = $"Se ha recibido informacion del correo <h1>{email}</h1> <br> " +
                $"<p>{comentario}</p>";

            smtp.Send(mail);

            return true;
        }
    }
}
