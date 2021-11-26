using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba_Automapper.Models
{
    public partial class Lectura
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int CodAutor { get; set; }
        public DateTime? Fecha { get; set; }
        public int Calificacion { get; set; }
        public string Comentario { get; set; }
        public bool Ebook { get; set; }
        public DateTime? FechaInicio { get; set; }
        public int? Paginas { get; set; }
    }
}
