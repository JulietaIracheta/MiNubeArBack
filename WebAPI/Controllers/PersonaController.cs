using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public PersonaController(minubeDBContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;

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
    }
}