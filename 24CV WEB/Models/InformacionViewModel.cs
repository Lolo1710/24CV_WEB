using System.Diagnostics;
using System.Drawing;
using System;
using System.Net.Sockets;

namespace _24CV_WEB.Models
{
	public class InformacionViewModel
	{
		public string Nombre { get; set; }
		public string Apellidos { get; set; }
		public string Email { get; set; }
		public DateOnly FechaNacimiento { get; set; }
		public SelectMode Turno { get; set; }
		public enum SelectMode
		{
			Matutino,
			Vespertino
		}
		public string Comentarios { get; set; }
	}

}
