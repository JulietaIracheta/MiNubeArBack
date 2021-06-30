using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Dto;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface IInstitucionCursoRepository
    {
        List<InstitucionCurso> Crear(InstitucionCursoDto institucionCurso);
    }
    public class InstitucionCursoRepository : IInstitucionCursoRepository
    {
        private readonly minubeDBContext _context;

        public InstitucionCursoRepository(minubeDBContext context)
        {
            _context = context;
        }

        public List<InstitucionCurso> Crear(InstitucionCursoDto institucionCurso)
        {
            throw new NotImplementedException();
        }
    }
}

   
