using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly minubeDBContext _context;

        public EventoController(minubeDBContext context)
        {
            _context = context;
        }

        // GET: api/Evento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEventos()
        {
            return await _context.Evento.ToListAsync();
        }

        // GET: api/evento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEvento(int id)
        {
            var evento = await _context.Evento.FindAsync(id);

            if (evento == null)
            {
                return NotFound();
            }

            return evento;
        }

        // PUT: api/evento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento(int id, Evento evento)
        {
            evento.IdEvento = id;

            _context.Entry(evento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(id))
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

        // POST: api/evento
        [HttpPost]
        public async Task<ActionResult<Evento>> PostEvento(Evento evento)
        {

            var user = new Evento
            {
                Title = evento.Title,
                Start = evento.Start,
                IdCurso = 1,
                Url = evento.Url,
                
               
            };

            _context.Evento.Add(user);
            if (!EventoExists(user.IdEvento))
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetEvento", new { id = evento.IdEvento }, evento);
            }
            else
            {
                return BadRequest(new { message = "Evento ya existe en Base de Datos" });
            }

        }

        // DELETE: api/evento/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Evento>> DeleteEvento(int id)
        {
            var evento = await _context.Evento.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            _context.Evento.Remove(evento);
            await _context.SaveChangesAsync();

            return evento;
        }

        private bool EventoExists(int id)
        {
            return _context.Evento.Any(e => e.IdEvento == id);
        }
    }
}

