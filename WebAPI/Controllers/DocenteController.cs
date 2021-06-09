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
        private readonly minubeDBContext _context;
        private readonly JwtService _jwtService;

        public DocenteController(minubeDBContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
         
        }

        [HttpGet("{id}")]
        public IQueryable<Instituciones> GetInstitucionesDocente(int id)
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtService.Verify(jwt);
            id = Convert.ToInt32(token.Issuer);
            var institucion = _context.InstitucionDocente.Where(x => x.IdDocente == id).Select(x => x.IdInstitucionNavigation);
            

            return institucion;
        }

        [HttpGet("getCursos/{id}")]
        public IQueryable<Cursos> GetCursosDocente(int id)
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtService.Verify(jwt);
            id = Convert.ToInt32(token.Issuer);
            
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

        [HttpGet("getId")]
        public int GetIDDocente()
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtService.Verify(jwt);
            var userId = Convert.ToInt32(token.Issuer);
            return userId;
        }
       
    }
}
