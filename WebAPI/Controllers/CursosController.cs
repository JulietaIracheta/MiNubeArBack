using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dto;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly minubeDBContext _context;
       

        public CursosController(minubeDBContext context)
        {
            _context = context;

        }

        // GET: api/Cursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cursos>>> GetCursos()
        {
            return await _context.Cursos.ToListAsync();
        }

        // GET: api/curso/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cursos>> GetCurso(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);

            if (curso == null)
            {
                return NotFound();
            }

            return curso;
        }

        // PUT: api/curso/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, Cursos curso)
        {
            curso.IdCurso = id;

            _context.Entry(curso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoExists(id))
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

        // POST: api/curso
        [HttpPost]
        public async Task<ActionResult<Cursos>> PostCurso(Cursos curso)
        {

            var user = new Cursos
            {
                Nombre = curso.Nombre
            };

            _context.Cursos.Add(user);
            if (!CursoExists(user.IdCurso))
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetCurso", new { id = curso.IdCurso }, curso);
            }
            else
            {
                return BadRequest(new { message = "Curso ya existe en Base de Datos" });
            }

        }

        // DELETE: api/curso/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cursos>> DeleteCurso(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();

            return curso;
        }

        private bool CursoExists(int id)
        {
            return _context.Cursos.Any(e => e.IdCurso == id);
        }

        [HttpGet("getCursosDeUnaInstitucion/{id}")]
        public List<Cursos> getCursosDeUnaInstitucion(int id){
            var cursos = _context.InstitucionCurso.Where(x => x.IdInstitucion == id).Select( x => x.IdCursoNavigation ).ToList();
            return cursos;
        }


        [HttpPost("AsignaEstudiandesAcurso")]
        public async Task<ActionResult<EstudiantesDeUnCursoDto>> AsignaEstudiandesAcurso(EstudiantesDeUnCursoDto data)
        {
            try
            {
                for (int i = 0; i < data.IdEstudiantes.Length ; i++)
                {
                    _context.EstudianteCurso.Add(new EstudianteCurso{IdCurso = data.IdCurso, IdUsuario = data.IdEstudiantes[i]});
                }
                await _context.SaveChangesAsync();
                return data;
            }
            catch (System.Exception)
            {
               return NotFound();
            }
        }
      
    }
}
