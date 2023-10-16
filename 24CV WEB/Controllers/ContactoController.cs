using _24CV_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace _24CV_WEB.Controllers
{
    public class ContactoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviarCorreo(string email, string comentarios)
        {
            TempData["Email"] = email;
            TempData["Comentario"] = comentarios;

            return View("Index");
        }

        public IActionResult EnviarInformacion(EmailViewModel model)
        {
			TempData["Email"] = model.Email;
			TempData["Comentario"] = model.Comentario;

            SendEmail(model.Email, model.Comentario);

			return View("Index", model);
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
