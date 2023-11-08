using MiFormulario.Models;
using System.Net.Mail;
using System.Net;

namespace MiFormulario.Services
{
    public class EmailService : IEmailService
    {
        public bool SendEmail(string email)
        {
            bool result = false;

            try
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
                mail.Body = $"Se ha recibido informacion del correo <h1>{email}</h1> <br> ";
                smtp.Send(mail);
                result = true;
            }
            catch (Exception e)
            {

            }

            return result;
        }

        public bool ProcesarSolicitud(EmailViewModelExtenso data)
        {
            bool result = false;
            try
            {
                MailMessage mail = new MailMessage();

                SmtpClient smtp = new SmtpClient("mail.ulatransfers.com", 465);

                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("info@ulatransfers.com", "LOLOlolo10.");

                mail.From = new MailAddress("info@ulatransfers.com", "Ula Transfers");
                mail.To.Add(data.Email);
                mail.Subject = "Notificación de contacto";
                mail.IsBodyHtml = true;
                mail.Body = $"Se ha contactado la persona con el correo {data.Email} para solicitar información<br><br>" +
                            "Sus datos:<br>" +
                            $"Nombre: {data.Nombre}<br>" +
                            $"Apellido: {data.Apellido}<br>" +
                            $"Correo: {data.Email}<br>" +
                            $"Fecha de nacimiento: {data.FechaNacimiento}<br>" +
                            $"Hora de entrada: {data.HoraEntrada}<br>" +
                            $"Turno: {data.Turno}<br>" +
                            $"Mensaje: {data.Mensaje}";
                smtp.Send(mail);
                result = true;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool SendEmailWithData(EmailData data)
        {
            bool result = false;

            try
            {
                MailMessage mail = new MailMessage();

                SmtpClient smtp = new SmtpClient("mail.ulatransfers.com", 465);

                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("info@ulatransfers.com", "LOLOlolo10.");
                mail.To.Add(data.Email);
                mail.Subject = data.Subject;
                mail.IsBodyHtml = true;
                mail.Body = data.Content;

                smtp.Send(mail);
            }
            catch (Exception e)
            {

            }

            return result;
        }
    }
}
