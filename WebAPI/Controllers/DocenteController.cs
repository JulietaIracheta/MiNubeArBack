using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Dto;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocenteController : ControllerBase
    {
        private const string V = "getInstitucionesDeUnDocente/{id}";
        private readonly minubeDBContext _context;
        private readonly JwtService _jwtService;

        public DocenteController(minubeDBContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
         
        }

        [HttpGet("getInstitucion")]
        public IQueryable<Instituciones> GetInstitucionesDocente(string jwt)
        {
            //var jwt = Request.Cookies["jwt"];
            var token = _jwtService.Verify(jwt);
            var id = Convert.ToInt32(token.Issuer);
            var institucion = _context.InstitucionDocente.Where(x => x.IdDocente == id)
                .Select(x => x.IdInstitucionNavigation);
            
            return institucion;
        }
        
        [HttpGet(V)]
        public List<Instituciones> getInstitucionesDeUnDocente(int id)
        {
            var institucion = _context.InstitucionDocente.Where(x => x.IdDocente == id).Select(x => x.IdInstitucionNavigation).ToList();
            return institucion;
        }

        [HttpGet("getCursos")]
        public IQueryable<Cursos> GetCursosDocente(string jwt)
        {
            //var jwt = Request.Cookies["jwt"];
            var token = _jwtService.Verify(jwt);
            int id = Convert.ToInt32(token.Issuer);

            var curso = _context.CursoDocente.Where(x => x.IdDocente == id).Select(x => x.IdCursoNavigation);

            return curso;
        }
        [HttpGet("getEstudiantesPorCurso/{idInstitucion}/{idCurso}")]
        public List<PersonaDto> GetEstudiantesCurso(int idInstitucion,int idCurso)
        {
            var usuariosPorCursos = _context.EstudianteCurso
                .Where(x => x.IdCurso == idCurso &&
                            x.IdUsuarioNavigation.InstitucionEstudiante.Any(ic => ic.IdInstitucion == idInstitucion))
                .Include(x => x.IdUsuarioNavigation)
                .ThenInclude(x => x.IdPersonaNavigation).Select(u => new PersonaDto
                {
                    IdPersona = u.IdUsuarioNavigation.IdPersona.Value,
                    IdUsuario = u.IdUsuario,
                    Nombre = u.IdUsuarioNavigation.IdPersonaNavigation.Nombre,
                    Apellido = u.IdUsuarioNavigation.IdPersonaNavigation.Apellido,
                    Avatar = u.IdUsuarioNavigation.Avatar
                });

            return usuariosPorCursos.ToList();
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

        [HttpGet("getId")]
        public int GetIDDocente(string jwt)
        {
            //var jwt = Request.Cookies["jwt"];
            var token = _jwtService.Verify(jwt);
            var userId = Convert.ToInt32(token.Issuer);
            return userId;
        }
       
    }
}
