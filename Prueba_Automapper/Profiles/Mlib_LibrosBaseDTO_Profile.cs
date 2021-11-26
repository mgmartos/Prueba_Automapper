using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Prueba_Automapper.DTO;
using Prueba_Automapper.Models;

namespace Prueba_Automapper.Profiles
{
    public class Mlib_LibrosBaseDTO_Profile : Profile
    {
       public Mlib_LibrosBaseDTO_Profile()
        {
            CreateMap<Mlib, LibrosBaseDTO>();
        }
    }
}
