using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebAPI.Dto;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocenteController : ControllerBase
    {
        private readonly minubeDBContext _context;

        public DocenteController(minubeDBContext context)
        {
            _context = context;

        }

        [HttpGet("{id}")]
        public IQueryable<Instituciones> GetInstitucionesDocente(int id)
        {

            var institucion = _context.InstitucionDocente.Where(x => x.IdDocente == id).Select(x => x.IdInstitucionNavigation);
            

            return institucion;
        }

        [HttpGet("getCursos/{id}")]
        public IQueryable<Cursos> GetCursosDocente(int id)
        {
            var curso = _context.CursoDocente.Where(x => x.IdDocente == id).Select(x => x.IdCursoNavigation);


            return curso;
        }
        [HttpGet("getEstudiantesPorCurso/{id}")]
        public List<PersonaDto> GetEstudiantesCurso(int id)
        {
            var usuariosPorCursos = _context.EstudianteCurso.Where(x => x.IdCurso == id).Include(x => x.IdUsuarioNavigation)
                .ThenInclude(x => x.IdPersonaNavigation).Select(u => new PersonaDto
                {
                    IdPersona = u.IdUsuarioNavigation.IdPersona.Value,
                    IdUsuario = u.IdUsuario,
                    Nombre = u.IdUsuarioNavigation.IdPersonaNavigation.Nombre,
                    Apellido = u.IdUsuarioNavigation.IdPersonaNavigation.Apellido,
                });

            return usuariosPorCursos.ToList();
        }
    }
}
