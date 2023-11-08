﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiFormulario.Models
{
    [Table("Curriculums")]
    public class Curriculum
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "El campo nombre es requerido.")]
		[StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
		public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo apellido paterno es requerido.")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public string ApellidoPaterno { get; set; }
        [Required(ErrorMessage = "El campo apellido materno es requerido.")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public string ApellidoMaterno { get; set; }
        [Required(ErrorMessage = "El campo CURP es obligatorio.")]
        [StringLength(18, ErrorMessage = "Máximo 18 caracteres.")]
        public string CURP { get; set; }
        [Required(ErrorMessage = "El campo RFC es obligatorio.")]
        [StringLength(13, ErrorMessage = "Máximo 13 caracteres.")]
        public string RFC { get; set; }
        [DataType(DataType.Date)]
		[Required(ErrorMessage = "La fecha de nacimiento es obligatorio.")]
		public DateTime FechaNacimiento { get; set; }
		public string Dirección { get; set; }
		[DataType(DataType.EmailAddress)]
		[Required]
		public string Email { get; set; }
		[Range(0, 100)]
		public int PorcentajeIngles { get; set; }
        [NotMapped]
        public IFormFile? Foto { get; set; }
        public string RutaFoto { get; set; }
	}
}
