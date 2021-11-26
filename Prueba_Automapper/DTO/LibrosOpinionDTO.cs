using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Automapper.DTO
{
    public class LibrosOpinionDTO
    {
        public string Titulo { get; set; }
         public string Tema { get; set; }
        public int? Calificacion { get; set; }
        public int? Paginas { get; set; }
        public string Comentario { get; set; }
        public int? Numobras { get; set; }
        public string Origen { get; set; }
        public int CodAutor { get; set; }
    }
}
