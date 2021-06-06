using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dto;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly minubeDBContext _context;
        private readonly JwtService _jwtService;
        private readonly PersonaRepository personaRepository;

        public PersonaController(minubeDBContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
            personaRepository = new PersonaRepository(context);
        }

        [HttpGet("getPersonaByUsuario")]
        public PersonaDto GetPersonaByUsuario()
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtService.Verify(jwt);

            var userId = Convert.ToInt32(token.Issuer);
            var persona = _context.Usuarios.Include(p => p.IdPersonaNavigation).First(e => e.IdUsuario == userId)
                .IdPersonaNavigation;
            return new PersonaDto
            {
                Apellido = persona.Apellido, Email = persona.Email, IdPersona = persona.IdPersona,
                Nombre = persona.Nombre,
                Telefono = persona.Telefono
            };
        }
        // GET: api/Usuario
        [HttpGet]
        public List<PersonaDto> GetUsuarios()
        {

            return personaRepository.GetAll();
        }
        
        [HttpGet("getPerfil/{id}")]
        public PersonaDto GetPerfilDeEstudiante(int id)
        {
            return personaRepository.GetPersona(id);
        }
        [HttpGet("getEstudiantesAsignados/{id}")]
        public List<PersonaDto> GetEstudiantesAsignados(int id)
        {
            return personaRepository.GetEstudiantesAsignados(id);
        }

        [HttpGet("getEstudiantesCurso/{id}")]
        public IQueryable<EstudianteCurso> GetEstudiantesCurso(int id)
        {
            var user = _context.EstudianteCurso.Where(x => x.IdCurso == id).Include(x=>x.IdUsuarioNavigation).ThenInclude(x=>x.IdPersonaNavigation);
           
            return user;
        }

    }
}