
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dto;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase
    {
        private readonly minubeDBContext _context;
        private readonly JwtService _jwtService;

        public MateriasController(minubeDBContext context, JwtService jwtService)
        {
            _jwtService = jwtService;
            _context = context;
        }

        // GET: api/Materias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Materias>>> GetMaterias()
        {
            return await _context.Materias.ToListAsync();
        }

        // GET: api/Materia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Materias>> GetMateria(int id)
        {
            var materia = await _context.Materias.FindAsync(id);

            if (materia == null)
            {
                return NotFound();
            }

            return materia;
        }

        // PUT: api/materia/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMateria(int id, Materias materia)
        {
            materia.IdMateria = id;

            _context.Entry(materia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MateriaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/materia
        [HttpPost]
        public async Task<ActionResult<Materias>> PostMateria(Materias materia)
        {

            var user = new Materias
            {
                Nombre = materia.Nombre,
                Icon = ""
            };

            _context.Materias.Add(user);
            if (!MateriaExists(user.IdMateria))
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetMateria", new { id = materia.IdMateria }, materia);
            }
            else
            {
                return BadRequest(new { message = "Materia ya existe en Base de Datos" });
            }

        }

        // DELETE: api/Materia/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Materias>> DeleteMateria(int id)
        {
            var materia = await _context.Materias.FindAsync(id);
            if (materia == null)
            {
                return NotFound();
            }

            _context.Materias.Remove(materia);
            await _context.SaveChangesAsync();

            return materia;
        }

        private bool MateriaExists(int id)
        {
            return _context.Materias.Any(e => e.IdMateria == id);
        }
        [HttpGet("getMateriasDocente/{id}")]
        public ActionResult<DocenteMateriasDto> GetMaterias(int id, string jwt)
        {
            //var jwt = Request.Cookies["jwt"];
            var token = _jwtService.Verify(jwt);

            var userId = Convert.ToInt32(token.Issuer);


            var materias = _context.MateriaCurso.Include(m => m.IdMateriaNavigation).ThenInclude(e => e.MateriaDocente)
                .Where(m => m.IdCurso == id &&
                            m.IdMateriaNavigation.MateriaDocente.Any(e => e.IdUsuario == userId))
                .Select(m => new DocenteMateriasDto
                {
                    Nombre = m.IdMateriaNavigation.Nombre,
                    IdCurso = m.IdCurso,
                    Icon = m.IdMateriaNavigation.Icon,
                    IdMateria = m.IdMateria
                }).ToList();

            return materias.Any() ? Ok(materias) : Ok(new { message = "sin materias" });
        }
    }
}
