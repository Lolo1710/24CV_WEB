using _24CV_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.Net.Sockets;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;


namespace _24CV_WEB.Controllers
{
	public class FormularioController : Controller
	{
		public IActionResult Contacto()
		{
			return View();
		}

		public IActionResult EnviarInformacion(InformacionViewModel model)
		{
			TempData["Nombre"] = model.Nombre;
			TempData["Apellidos"] = model.Apellidos;
			TempData["Email"] = model.Email;
			TempData["FechaNacimiento"] = model.FechaNacimiento;
			TempData["Turno"] = model.Turno;
			TempData["Comentarios"] = model.Comentarios;

			ProcesarSolicitud(model.Nombre, model.Apellidos, model.Email, model.FechaNacimiento, model.Turno, model.Comentarios);

			return View("Contacto", model);
		}

		public bool ProcesarSolicitud(string nombre, string apellidos, string email, DateOnly fechanacimiento, InformacionViewModel.SelectMode turno, string comentario)
		{
			MailMessage mail = new MailMessage();

			SmtpClient smtp = new SmtpClient("mail.ulatransfers.com", 587);

			smtp.EnableSsl = true;
			smtp.UseDefaultCredentials = false;
			smtp.Credentials = new NetworkCredential("info@ulatransfers.com", "LOLOlolo10.");

			mail.From = new MailAddress("info@ulatransfers.com", "Ula Transfers");
			mail.To.Add(email);
			mail.Subject = "Formulario de Contacto";
			mail.IsBodyHtml = true;

			mail.Body = "<body>" +
				$"<p> Nombre: {nombre}</p>" +
				$"<p> Apellidos: {apellidos}</p>" +
				$"<p> Email: {email}</p>" +
				$"<p> Fecha de Nacimiento: {fechanacimiento}</p>" +
				$"<p> Turno: {turno}</p>" +
				$"<p> Comentario: {comentario}</p>" +
				"</body>";


			smtp.Send(mail);

			return true;
		}

	}
}
