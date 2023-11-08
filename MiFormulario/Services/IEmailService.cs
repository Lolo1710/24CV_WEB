using MiFormulario.Models;

namespace MiFormulario.Services
{
    public interface IEmailService
    {
        bool SendEmail(string email);
        bool ProcesarSolicitud(EmailViewModelExtenso data);
        bool SendEmailWithData(EmailData data);
    }
}
