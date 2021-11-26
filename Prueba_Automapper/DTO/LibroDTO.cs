using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Automapper.DTO
{
    public class LibroDTO
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public string Coleccion { get; set; }
        public DateTime? Fecha { get; set; }
        public string Tema { get; set; }
        public int? Calificacion { get; set; }
        public int? Paginas { get; set; }
        public string Comentario { get; set; }
        public string Prestamo { get; set; }
        public DateTime? FechaPrestamo { get; set; }
        public int? Numobras { get; set; }
        public string Origen { get; set; }
        public int CodAutor { get; set; }
    }
}
