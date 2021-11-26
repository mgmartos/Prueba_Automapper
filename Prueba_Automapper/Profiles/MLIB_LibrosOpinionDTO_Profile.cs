using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Prueba_Automapper.DTO;
using Prueba_Automapper.Models;

namespace Prueba_Automapper.Profiles
{
    public class MLIB_LibrosOpinionDTO_Profile : Profile
    {
        public MLIB_LibrosOpinionDTO_Profile()
        {
            CreateMap<Mlib, LibrosOpinionDTO>();
        }
    }
}
