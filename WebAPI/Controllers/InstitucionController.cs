using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dto;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitucionController : ControllerBase
    {
        private readonly minubeDBContext _context;
       

        public InstitucionController(minubeDBContext context)
        {
            _context = context;

        }

        // GET: api/Instituciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instituciones>>> GetInstituciones()
        {
            return await _context.Instituciones.ToListAsync();
        }

        // GET: api/Institucion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Instituciones>> GetInstitucion(int id)
        {
            var institucion = await _context.Instituciones.FindAsync(id);

            if (institucion == null)
            {
                return NotFound();
            }

            return institucion;
        }

        // PUT: api/Institucion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstitucion(int id, Instituciones institucion)
        {
            institucion.IdInstitucion = id;

            _context.Entry(institucion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstitucionExists(id))
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

        // POST: api/Institucion
        [HttpPost]
        public async Task<ActionResult<Instituciones>> PostInstitucion(Instituciones institucion)
        {
            try{
                var user = new Instituciones
                {
                    Nombre = institucion.Nombre,
                    Email = institucion.Email,
                    Direccion = institucion.Direccion
                };

                _context.Instituciones.Add(user);

                if (!EmailExists(user.Email))
                {
                    await _context.SaveChangesAsync();
                    var institucionAgregada = _context.Instituciones.FirstOrDefault( item => item.Email == institucion.Email);
                    institucion.IdInstitucion = institucionAgregada.IdInstitucion;
                    return CreatedAtAction("GetInstitucion", new { id = institucion.IdInstitucion }, institucion);
                }
                else
                {
                    institucion.Email = "";
                    return CreatedAtAction("GetInstitucion", new { id = institucion.IdInstitucion }, institucion);

                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Email ya existe en Base de Datos" });
            }   
        }

       

        // DELETE: api/institucion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Instituciones>> DeleteInstitucion(int id)
        {
            var user = await _context.Instituciones.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Instituciones.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }


        [HttpGet("getInstitucionesDeUnEstudiante/{id}")]
        public List<Instituciones> getInstitucionesDeUnEstudiante(int id)
        {
            var institucion = _context.InstitucionEstudiante.Where(x => x.IdUsuario == id).Select(x => x.IdInstitucionNavigation).ToList();
            return institucion;
        }

        [HttpGet("getInstitucionDeUnEstudiante/{id}")]
        public InstitucionEstudiante getInstitucionDeUnEstudiante(int id)
        {
            var institucion = _context.InstitucionEstudiante.FirstOrDefault(x => x.IdUsuario == id);
            return institucion;
        }

        [HttpGet("getEstudiantesDeUnaInstitucion/{id}")]
        public List<Usuarios> getEstudiantesDeUnaInstitucion(int id)
        {
            var estudiantes = _context.InstitucionEstudiante.Where(x => x.IdInstitucion == id).Select(x => x.IdUsuarioNavigation).ToList();
            return estudiantes;
        }

        private bool InstitucionExists(int id)
        {
            return _context.Instituciones.Any(e => e.IdInstitucion == id);
        }

        private bool EmailExists(string email)
        {
            return _context.Instituciones.Any(e => e.Email == email);
        }


    }
}
