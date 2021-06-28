using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dto;
using WebAPI.Models;

namespace WebAPI.Data
{ 
     public interface IInstitucionCursoRepository
{
 
}


    public class InstitucionCursoRepository : IInstitucionCursoRepository
    {
        private readonly minubeDBContext _context;

        public InstitucionCursoRepository(minubeDBContext context)
        {
            _context = context;
        }
    }
}
