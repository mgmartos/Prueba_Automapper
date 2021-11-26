using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Prueba_Automapper.DTO;
using Prueba_Automapper.Models;

namespace Prueba_Automapper.Profiles
{
    public class MLib_LibroDTO_Profile : Profile
    {
        public MLib_LibroDTO_Profile()
        {
            CreateMap<Mlib, LibroDTO>();

            CreateMap<LibroDTO, Mlib>();
        }
    }
}
