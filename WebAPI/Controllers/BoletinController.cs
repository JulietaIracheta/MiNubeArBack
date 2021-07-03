using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class BoletinController : Controller
    {
        private readonly minubeDBContext _context;
        private readonly JwtService _jwtService;

        public BoletinController(minubeDBContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Boletin>>> GetBoletines()
        {
            return await _context.Boletin.ToListAsync();
        }

        [HttpGet("{id}")]
        public List<Boletin> GetBoletinEstudiante(int id)
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtService.Verify(jwt);
            id = Convert.ToInt32(token.Issuer);

            IQueryable<Boletin> boletin = from b in _context.Boletin
                                    where b.IdEstudiante == id
                                    select new Boletin
                                    {
                                        IdEstudiante = id,
                                        Año = b.Año,
                                        Materia = b.Materia,
                                        T1 = b.T1,
                                        T2 = b.T2,
                                        T3 = b.T3,
                                    };

            return boletin.ToList();
        }

        [HttpGet("estudiante/{id}")]
        public List<Boletin> GetBoletinesEstudiantes(int id)
        {

            IQueryable<Boletin> boletin = from b in _context.Boletin
                                          where b.IdEstudiante == id
                                          select new Boletin
                                          {
                                              IdEstudiante = id,
                                              Año = b.Año,
                                              Materia = b.Materia,
                                              T1 = b.T1,
                                              T2 = b.T2,
                                              T3 = b.T3,
                                          };

            return boletin.ToList();
        }

        [HttpGet("tutor/{id}")]
        public List<BoletinDto> GetBoletinEstudianteTutor(int id)
        {
                var jwt = Request.Cookies["jwt"];
              var token = _jwtService.Verify(jwt);
                id = Convert.ToInt32(token.Issuer);

            IQueryable<BoletinDto> boletin = from b in _context.Boletin
                                             join u in _context.Usuarios on b.IdEstudiante equals u.IdUsuario
                                             join t in _context.TutorEstudiante on u.IdUsuario equals t.IdUsuarioEstudiante
                                             where t.IdUsuarioTutor == id
                                             
                                             select new BoletinDto
                                          {
                                            
                                              Año = b.Año,
                                              Materia = b.Materia,
                                              Nombre = u.IdPersonaNavigation.Nombre,
                                              Apellido = u.IdPersonaNavigation.Apellido,
                                              T1 = b.T1,
                                              T2 = b.T2,
                                              T3 = b.T3,
                                          };

            return boletin.ToList();
        }

        [HttpPost]
        public async Task<ActionResult<Boletin>> PostBoletin(Boletin boletin)
        {

            var bol = new Boletin
            {
                IdEstudiante = boletin.IdEstudiante,
                Materia = boletin.Materia,
                Año = boletin.Año,
                T1 = boletin.T1,
                T2 = boletin.T2,
                T3 = boletin.T3,
            };

            _context.Boletin.Add(bol);
            await _context.SaveChangesAsync();
            return bol;
        }


        }
    }
