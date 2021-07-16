using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dto;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadesController : ControllerBase
    {
        private readonly ActividadesRepository actividadesRepository;
        private readonly minubeDBContext _context;
        private readonly JwtService _jwtService;

        public ActividadesController(minubeDBContext context, JwtService jwtService)
        {
            _context = context;
            actividadesRepository = new ActividadesRepository(context);
            _jwtService = jwtService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuntajeActividad>>> GetActividades()
        {
            return await _context.PuntajeActividades.ToListAsync();
        }

        [HttpGet("calcularAvance/{id}")]
        public double CalcularAvanceActividades(int id)
        {
            return actividadesRepository.calcularAvance(id);
        }

        [HttpGet("calcularAvance/{idMateria}/{idUnidad}/{idEstudiante}")]
        public double CalcularAvanceActividades(int idEstudiante, int idMateria, int idUnidad)
        {
            return actividadesRepository.calcularAvanceActividadesMateriaUnidad(idEstudiante, idMateria, idUnidad);
        }

        [HttpGet("calcularAvance/{idMateria}/{userId}")]
        public double CalcularAvanceActividadesMateria(int idMateria)
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtService.Verify(jwt);

            var userId = Convert.ToInt32(token.Issuer);
            return actividadesRepository.calcularAvanceActividadesMateria(userId, idMateria);
        }

        [HttpGet("getActidades/{idMateria}/{unidad}")]
        public List<ActividadDto> GetActividades(int idMateria, int unidad, string jwt)
        {
            //var jwt = Request.Cookies["jwt"];
            var token = _jwtService.Verify(jwt);

            var userId = Convert.ToInt32(token.Issuer);

            return actividadesRepository.getActividades(userId, unidad, idMateria);
        }

        [HttpGet("getActidades/{idMateria}")]
        public List<ActividadMateriaDto> GetActividadesMateria(int idMateria)
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtService.Verify(jwt);

            var userId = Convert.ToInt32(token.Issuer);

            return actividadesRepository.getActividadMateria(userId,  idMateria);
        }
    }
}
