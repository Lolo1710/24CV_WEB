namespace MiFormulario.Models
{
    public class EmailViewModelExtenso
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public TimeOnly HoraEntrada { get; set; }
        public string Turno { get; set; }
        public string Email { get; set; }
        public string Mensaje { get; set; }
    }
}
