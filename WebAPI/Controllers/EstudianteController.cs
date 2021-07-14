using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            List<EstudianteMateriasDto> materias = estudianteRepository.GetMaterias(userId);

            if (materias.Count() > 0)
            {
                return Ok(materias);
            }

            return NotFound("Sin materias");
        }
    }
}
