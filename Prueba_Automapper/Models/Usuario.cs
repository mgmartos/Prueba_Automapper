using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba_Automapper.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public DateTime FechaAutorizado { get; set; }
        public int Permisos { get; set; }
    }
}
