using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Data;
using WebAPI.Dto;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly minubeDBContext _context;
        private readonly JwtService _jwtService;
        private readonly TutorRepository tutorRepository;
        public TutorController(minubeDBContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
            tutorRepository = new TutorRepository(context);

        }

        [HttpGet]
        public List<TutorEstudianteDto> GetEstudiantes(string jwt)
        {
            var token = _jwtService.Verify(jwt);
            var id = Convert.ToInt32(token.Issuer);
            return tutorRepository.GetEstudiantesTutor(id);
        }

        [HttpGet("materias")]
        public ActionResult<EstudianteMateriasDto> GetMaterias(int id)
        {
            List<EstudianteMateriasDto> materias = tutorRepository.GetMaterias(id);

            if (materias.Count() > 0)
            {
                return Ok(materias);
            }

            return Ok(new { message = "sin materias" });
        }

    }
}
