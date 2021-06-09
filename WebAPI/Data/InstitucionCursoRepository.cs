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
            var institucionCursos = new List<InstitucionCurso>();
           
       //     if (!institucionCurso.IdInstCurso.Any())
           institucionCurso.IdInstCurso = _context.Cursos.Where(x => x.IdCurso == institucionCurso.IdCurso)
                    .Select(u => u.IdCurso).ToList();

            foreach (var IdInstCursos in institucionCurso.IdInstCurso)
            {
                var cursos = new InstitucionCurso { IdInstitucion = institucionCurso.IdInstitucion };
                cursos.IdCurso = IdInstCursos;
                institucionCursos.Add(cursos);
            }

            _context.InstitucionCurso.AddRange(institucionCursos);
            _context.SaveChanges();
            return institucionCursos;
        }
    }
}
