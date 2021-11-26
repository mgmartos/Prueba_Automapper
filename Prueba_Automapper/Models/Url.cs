using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba_Automapper.Models
{
    public partial class Url
    {
        public int Tipo { get; set; }
        public int CodigoPadre { get; set; }
        public string Direccion { get; set; }
        public string Descripcion { get; set; }
    }
}
