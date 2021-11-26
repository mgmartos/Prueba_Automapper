using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Automapper.DTO
{
    public class LibrosBaseDTO
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public string Coleccion { get; set; }
        public int? Paginas { get; set; }

    }
}
