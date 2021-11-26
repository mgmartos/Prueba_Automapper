using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prueba_Automapper.DTO;
using Prueba_Automapper.Interfaces;
using Prueba_Automapper.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Prueba_Automapper.Utils;

namespace Prueba_Automapper.Repository
{
    public class Mlib_WithDTO : IMlib_WithDTO
    {
        private readonly biblosContext _context;
        private readonly IMapper _mapper;
        //        private readonly ILogger _logger;
        private Loggin _logger;

        public Mlib_WithDTO(biblosContext context, IMapper mapper, ILogin login/*, ILoggerFactory loggerfactory*/)
        {
            _context = context;
            _mapper = mapper;
            //_logger = loggerfactory.CreateLogger(typeof(Mlib_WithDTO));
            _logger = (Loggin)login;
        }

        // Altas
        public async Task<Mlib> CrearMlib(LibroDTO dto)
        {
            Mlib Libro = new Mlib();
            //Libro.Titulo = dto.Titulo;
            //Libro.Autor = dto.Autor;
            //Libro.Calificacion = dto.Calificacion;
            //Libro.CodAutor = dto.CodAutor;
            //Libro.Coleccion = dto.Coleccion;
            //Libro.Comentario = dto.Comentario;
            //Libro.Editorial = dto.Editorial;
            //Libro.Fecha = dto.Fecha;
            //Libro.FechaPrestamo = dto.FechaPrestamo;
            //Libro.Numobras = dto.Numobras;
            //Libro.Origen = dto.Origen;
            //Libro.Paginas = dto.Paginas;
            //Libro.Prestamo = dto.Prestamo;
            //Libro.Tema = dto.Tema;
            //Mlib Libro;
            try
            {
                Libro = (Mlib)_mapper.Map<Mlib>(dto);
                //Mlib ll = _mapper.Map<Mlib>(dto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            
            _context.Mlibs.Add(Libro);

            await _context.SaveChangesAsync();
            
            return Libro;
        }

        // Bajas
        // Task<IActionResult> DeleteMlib(int id)


        // Modificaciones
        public async Task<int> UpdateMlib(int id, LibroDTO dto)
        {
            var libro = this._context.Mlibs.Where(l => l.IdLibro == id).FirstOrDefault();
            //libro.Titulo = dto.Titulo;
            //libro.Autor = dto.Autor;
            //libro.Calificacion = dto.Calificacion;
            //libro.CodAutor = dto.CodAutor;
            //libro.Coleccion = dto.Coleccion;
            //libro.Comentario = dto.Comentario;
            //libro.Editorial = dto.Editorial;
            //libro.Fecha = dto.Fecha;
            //libro.FechaPrestamo = dto.FechaPrestamo;
            //libro.Numobras = dto.Numobras;
            //libro.Origen = dto.Origen;
            //libro.Paginas = dto.Paginas;
            //libro.Prestamo = dto.Prestamo;
            //libro.Tema = dto.Tema;
            libro = _mapper.Map<Mlib>(dto);

            return await this._context.SaveChangesAsync();
        }

        // Consultas

        public async Task<IEnumerable<Mlib>> GetMlibs()
        {

            //IQueryable<Mli> productsQuery = from product in context.Products
            //                                    select product;


            IQueryable<string> productsQuery = from libros in _context.Mlibs
                                            select libros.Titulo;

            // Pruebas LINQ
           // string ww = productsQuery.First();

           // var lista = from libro in _context.Mlibs
           //             from autor in _context.Autores
           //             where libro.CodAutor == autor.IdAutor
           //             orderby libro.Titulo
           //             select new
           //             {
           //                 Titulo = libro.Titulo,
           //                 Autor = autor.NombreAutor
           //             };
           //// var lista2 = lista.ElementAt()
           //// Console.WriteLine(lista2.Titulo);


           // foreach(var l in lista)
           // {
           //     string tit = l.Titulo;
           //     string aut = l.Autor;
           //     Console.WriteLine(tit);
           // }


           // int y = 0;
           // y++;


            return await this._context.Mlibs.ToListAsync();

        }

        public async Task<ActionResult<Mlib>> GetMlib(int id)
        {
            var mlib = await _context.Mlibs.FindAsync(id);

            //if (mlib == null)
            //{
            //    return null;
            //}

            LibroDTO dto = _mapper.Map<LibroDTO>(mlib);
            DateTime ts = DateTime.Now;

            _logger.LogInformation("Obtenido el libro " + dto.Titulo + " a las " + String.Format("{0:00}:{1:00}:{2:00}:{3:00}",
                ts.Hour, ts.Minute, ts.Second, ts.Millisecond));
            try {
                Mlib mlib1 = _mapper.Map<Mlib>((Object)dto);
                Mlib ll = mlib1;
                }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return mlib;
        }

        // Mapeados
        public async Task<LibrosBaseDTO> Recovery_Libro_Base(int id)
        {
            var mlib = await _context.Mlibs.FindAsync(id);
            return _mapper.Map<LibrosBaseDTO>(mlib);

            //LibrosBaseDTO ldto = new LibrosBaseDTO();
            //ldto.Autor = mlib.Autor;
            //ldto.Coleccion = mlib.Coleccion;
            //ldto.Editorial = mlib.Editorial;
            //ldto.Paginas = mlib.Paginas;
            //ldto.Titulo = mlib.Titulo;
            //return ldto;

        }
        public async Task<List<LibrosBaseDTO>> Recovery_Libros_Base()
        {
            /* return await this._context.Mlibs.Select(l => new LibrosBaseDTO()
             {
                 Autor = l.Autor,
                 Coleccion = l.Coleccion,
                 Editorial = l.Editorial,
                 Paginas = l.Paginas,
                 Titulo = l.Titulo
             }).ToListAsync();*/

            var libros = await _context.Mlibs.ToListAsync();
            return _mapper.Map<List<LibrosBaseDTO>>(libros);
 
           
            
            
            //var lista = await this._context.Mlibs.ToListAsync();
            //List<LibrosBaseDTO> lDto = new List<LibrosBaseDTO>();
            //foreach (Mlib l in lista)
            //{
            //    LibrosBaseDTO ldto = new LibrosBaseDTO();
            //    ldto.Autor = l.Autor;
            //    ldto.Coleccion = l.Coleccion;
            //    ldto.Editorial = l.Editorial;
            //    ldto.Paginas = l.Paginas;
            //    ldto.Titulo = l.Titulo;
            //    lDto.Add(ldto);
            //}

            //return lDto;
        }

        public async Task<LibrosOpinionDTO> Recovery_Libro_Opinion(int id)
        {
           //var mlib = await _context.Mlibs.FindAsync(id);

           // LibrosOpinionDTO ldto = new LibrosOpinionDTO();
           // ldto.Calificacion = mlib.Calificacion;
           // ldto.CodAutor = mlib.CodAutor;
           // ldto.Comentario = mlib.Comentario;
           // ldto.Numobras = mlib.Numobras;
           // ldto.Origen = mlib.Origen;
           // ldto.Paginas = mlib.Paginas;
           // ldto.Tema = mlib.Tema;
           // ldto.Titulo = mlib.Titulo;

            //return ldto;

            var item = await (_context.Mlibs.FirstOrDefaultAsync(s => s.IdLibro == id));
            return _mapper.Map<LibrosOpinionDTO>(item);
            //LibrosOpinionDTO l = new LibrosOpinionDTO() { Calificacion = item.Calificacion,
            //                                              CodAutor = item.CodAutor,
            //                                              Comentario = item.Comentario,
            //                                              Numobras = item.Numobras,
            //                                              Origen = item.Origen,
            //                                              Paginas = item.Paginas,
            //                                              Tema = item.Tema,
            //                                              Titulo = item.Titulo
            //                };

            //return l;
         }
        public async Task<List<LibrosOpinionDTO>> Recovery_Libros_Opinion()
        {

            //return await this._context.Mlibs.Select(l => new LibrosOpinionDTO()
            //{
            //    Calificacion = l.Calificacion,
            //    CodAutor = l.CodAutor,
            //    Comentario = l.Comentario,
            //    Numobras = l.Numobras,
            //    Origen = l.Origen,
            //    Paginas = l.Paginas,
            //    Tema = l.Tema,
            //    Titulo = l.Titulo
            //}).ToListAsync();
            var lista = await this._context.Mlibs.ToListAsync();
            return _mapper.Map<List<LibrosOpinionDTO>>(lista);




            //var lista = await this._context.Mlibs.ToListAsync();
            //List<LibrosOpinionDTO> lDto = new List<LibrosOpinionDTO>();
            //foreach (Mlib mlib in lista)
            //{
            //    LibrosOpinionDTO ldto = new LibrosOpinionDTO();
            //    ldto.Calificacion = mlib.Calificacion;
            //    ldto.CodAutor = mlib.CodAutor;
            //    ldto.Comentario = mlib.Comentario;
            //    ldto.Numobras = mlib.Numobras;
            //    ldto.Origen = mlib.Origen;
            //    ldto.Paginas = mlib.Paginas;
            //    ldto.Tema = mlib.Tema;
            //    ldto.Titulo = mlib.Titulo;
            //}
            //return lDto;
        }

        public async Task<List<string>> GetTemas()
        {
            return await this._context.Mlibs.Select(t => t.Tema.Trim().ToUpper()).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<Mlib>> GetLibrosTema(string tema)
        {

            return await this._context.Mlibs.Where(t => t.Tema.Trim().ToLower() == tema.Trim().ToLower()).ToListAsync();
        }

        public async Task<List<string>> GetEditoriales()
        {
            return await this._context.Mlibs.Select(e => e.Editorial.Trim().ToUpper()).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<Mlib>> GetLibrosEditorial(string editorial)
        {
            return await this._context.Mlibs.Where(e => e.Editorial.Trim().ToLower() == editorial.Trim().ToLower()).ToListAsync();
        }

        public async Task<IEnumerable<Mlib>> GetLibrosEditorialTema(string editorial, string tema)
        {
            return await this._context.Mlibs.Where(e => e.Editorial.Trim().ToLower() == editorial.Trim().ToLower() && 
              e.Tema.Trim().ToLower() == tema.Trim().ToLower()).ToListAsync();
        }
    }
}
