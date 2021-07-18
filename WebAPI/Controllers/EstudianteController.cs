using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dto;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly minubeDBContext _context;
        private readonly JwtService _jwtService;
        private readonly PersonaRepository personaRepository;
        private readonly UsuarioRepository usuarioRepository;
        private readonly EstudianteRepository estudianteRepository;

        public EstudianteController(minubeDBContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
            personaRepository = new PersonaRepository(context);
            usuarioRepository = new UsuarioRepository(context);
            estudianteRepository = new EstudianteRepository(context);
        }

        [HttpGet("materias")]
        public ActionResult<EstudianteMateriasDto> GetMaterias(string jwt)
        {
            var token = _jwtService.Verify(jwt);

            var userId = Convert.ToInt32(token.Issuer);

            var materias = estudianteRepository.GetMaterias(userId);

            if (materias.Any())
            {
                return Ok(materias);
            }

            return NotFound("Sin materias");
        }
        [HttpGet("materiasDeEstudiante/{id}")]
        public ActionResult<EstudianteMateriasDto> GetMaterias(int id)
        {

            var materias = estudianteRepository.GetMaterias(id);

            if (materias.Any())
            {
                return Ok(materias);
            }

            return NotFound("Sin materias");
        }
        [HttpGet("getByCurso/{id}/{idInstitucion}")]
        public ActionResult<Usuarios> GetByCurso(int id, int idInstitucion)
        {
            var usuarios = _context.EstudianteCurso.Include(e => e.IdUsuarioNavigation).Where(e =>
                    e.IdCurso == id && e.IdCursoNavigation.InstitucionCurso.Any(e => e.IdInstitucion == idInstitucion))
                .Select(e=>e.IdUsuarioNavigation).ToList();

            if (usuarios.Any())
            {
                return Ok(usuarios);
            }

            return NotFound("Sin estudiantes");
        }
    }
}
