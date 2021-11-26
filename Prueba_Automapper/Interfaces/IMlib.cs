using Microsoft.AspNetCore.Mvc;
using Prueba_Automapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Automapper.Interfaces
{
    interface IMlib
    {
        // Altas
        Task<Mlib> CrearMlib(Mlib mlib);

        // Bajas
        Task<int> DeleteMlib(int id);

        // Modificaciones
        Task<IActionResult> UpdateMlib(int id, Mlib mlib);

        // Consultas

        Task<ActionResult<IEnumerable<Mlib>>> GetMlibs();
        Task<ActionResult<Mlib>> GetMlib(int id);
    }
}
