using Microsoft.AspNetCore.Mvc;
using Prueba_Automapper.DTO;
using Prueba_Automapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Automapper.Interfaces
{
    public interface IMlib_WithDTO
    {
        // Altas
        Task<Mlib> CrearMlib(LibroDTO dto);

        // Bajas
       // Task<IActionResult> DeleteMlib(int id);      
            
        // Modificaciones
        Task<int> UpdateMlib(int id, LibroDTO dto);

        // Consultas

        Task<IEnumerable<Mlib>> GetMlibs();
        Task<ActionResult<Mlib>> GetMlib(int id);

        // Mapeados
        Task<LibrosBaseDTO> Recovery_Libro_Base(int id);
        Task<List<LibrosBaseDTO>> Recovery_Libros_Base();

        Task<LibrosOpinionDTO> Recovery_Libro_Opinion(int id);
        Task<List<LibrosOpinionDTO>> Recovery_Libros_Opinion();

        Task<List<string>> GetTemas();

        Task<IEnumerable<Mlib>> GetLibrosTema(string Tema);

        Task<List<string>> GetEditoriales();

        Task<IEnumerable<Mlib>> GetLibrosEditorial(string editorial);

        Task<IEnumerable<Mlib>> GetLibrosEditorialTema(string editorial, string tema);


    }
}
