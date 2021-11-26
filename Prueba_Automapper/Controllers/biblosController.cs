using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba_Automapper.DTO;
using Prueba_Automapper.Models;
using Prueba_Automapper.Repository;
using Prueba_Automapper.Interfaces;

namespace Prueba_Automapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class biblosController : ControllerBase
    {
        private readonly IMlib_WithDTO _repository;

        public biblosController(IMlib_WithDTO repository)
        {
            _repository = repository;
        }

        // GET: api/biblos

        [HttpGet("libros")]
        public async Task<IEnumerable<Mlib>> GetMlibs()
        {
            //return await _context.Mlibs.ToListAsync();
            return await _repository.GetMlibs();


        }

        // GET: api/biblos/5
        //[HttpGet("{id}")]
        [HttpGet("libro")]
        public async Task<ActionResult<Mlib>> GetMlib(int id)
        {
            // var mlib = await _context.Mlibs.FindAsync(id);
            return await _repository.GetMlib(id);

            //if (mlib == null)
            //{
            //    return NotFound();
            //}

            //return mlib;
        }



        [HttpGet("librobaseDTO")]
        public async Task<LibrosBaseDTO> Recovery_Libro_Base(int id)

        {
            return await _repository.Recovery_Libro_Base(id);

        }


        [HttpGet("librosbaseDTO")]
        public async Task<List<LibrosBaseDTO>> Recovery_Libros_Base()

        {
            // var mlib = await _context.Mlibs.FindAsync(id);
            return await _repository.Recovery_Libros_Base();

            //if (mlib == null)
            //{
            //    return NotFound();
            //}

            //return mlib;
        }

        [HttpGet("librosopinionDTO")]
        public async Task<List<LibrosOpinionDTO>> Recovery_Libros_Opinion()

        {
            // var mlib = await _context.Mlibs.FindAsync(id);
            return await _repository.Recovery_Libros_Opinion();

            //if (mlib == null)
            //{
            //    return NotFound();
            //}

            //return mlib;
        }

        [HttpGet("libroopinionDTO")]
        public async Task<LibrosOpinionDTO> Recovery_Libro_Opinion(int id)

        {
            return await _repository.Recovery_Libro_Opinion(id);
        }


        // PUT: api/biblos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<int> UpdateMlib(int id, LibroDTO dto)
        {
            // if (id != mlib.IdLibro)
            // {
            //     return BadRequest();
            // }
            // _context.Entry(mlib).State = EntityState.Modified;
            //try
            // {
            //     await _context.SaveChangesAsync();
            // }
            // catch (DbUpdateConcurrencyException)
            // {
            //     if (!MlibExists(id))
            //     {
            //         return NotFound();
            //     }
            //     else
            //     {
            //         throw;
            //     }
            // }

            // return NoContent();

            return await _repository.UpdateMlib(id, dto);
        }


       
        // POST: api/biblos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mlib>> CrearMlib(LibroDTO librodto)
        {
            //_context.Mlibs.Add(mlib);
            //await _context.SaveChangesAsync();

            return await this._repository.CrearMlib(librodto);

            //return CreatedAtAction("GetMlib", new { id = mlib.IdLibro }, mlib);
        }

        // GET: api/biblos
        [HttpGet("temas")]
        public async Task<List<string>> GetTemas()
        {
            return await this._repository.GetTemas();
        }
        // GET: api/biblos
        [HttpGet("librostema")]
        public async Task<IEnumerable<Mlib>> GetLibrosTema(string tema)
        {
            return await this._repository.GetLibrosTema(tema);
        }

        // GET: api/biblos
        [HttpGet("editoriales")]
        public async Task<List<string>> GetEditoriales()
        {
            return await this._repository.GetEditoriales();
        }
        // GET: api/biblos
        [HttpGet("libroseditorial")]
        public async Task<IEnumerable<Mlib>> GetLibrosEditorial(string editorial)
        {
            return await this._repository.GetLibrosEditorial(editorial);
        }
        // GET: api/biblos
        [HttpGet("libroseditorialtema")]
        public async Task<IEnumerable<Mlib>> GetLibrosEditorialTema(string editorial, string tema)
        {
            return await this._repository.GetLibrosEditorialTema(editorial,tema);
        }


        /*  // DELETE: api/biblos/5
         [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteMlib(int id)
         {
             var mlib = await _context.Mlibs.FindAsync(id);
             if (mlib == null)
             {
                 return NotFound();
             }

             _context.Mlibs.Remove(mlib);
             await _context.SaveChangesAsync();

             return NoContent();
         }

         private bool MlibExists(int id)
         {
             return _context.Mlibs.Any(e => e.IdLibro == id);
         }


         [HttpGet("autores")]
         public async Task<ActionResult<IEnumerable<Autore>>> GETAutores()
         {
             return await _context.Autores.ToListAsync();
         }

         [HttpGet("autor")]
         public async Task<ActionResult<Autore>> GetAutor(int id)
         {
             var autor = await _context.Autores.FindAsync(id);

             if (autor == null)
             {
                 return NotFound();
             }

             return autor;
         }

         */
    }
}
