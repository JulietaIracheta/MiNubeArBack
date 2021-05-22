﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitucionController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public InstitucionController(ApplicationDBContext context)
        {
            _context = context;

        }

        // GET: api/Instituciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Institucion>>> GetInstituciones()
        {
            return await _context.Instituciones.ToListAsync();
        }

        // GET: api/Institucion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Institucion>> GetInstitucion(int id)
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
        public async Task<IActionResult> PutInstitucion(int id, Institucion institucion)
        {
            institucion.id = id;

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
        public async Task<ActionResult<Institucion>> PostInstitucion(Institucion institucion)
        {

            var user = new Institucion
            {
                nombre = institucion.nombre,
                email = institucion.email
            };

            _context.Instituciones.Add(user);

            if (!EmailExists(user.email))
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetInstitucion", new { id = institucion.id }, institucion);
            }
            else
            {
                return BadRequest(new { message = "Email ya existe en Base de Datos" });
            }
        }

        // DELETE: api/institucion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Institucion>> DeleteInstitucion(int id)
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

        private bool InstitucionExists(int id)
        {
            return _context.Instituciones.Any(e => e.id == id);
        }

        private bool EmailExists(string email)
        {
            return _context.Instituciones.Any(e => e.email == email);
        }


    }
}
