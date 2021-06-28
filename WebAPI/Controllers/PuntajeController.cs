using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dto;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuntajeController : ControllerBase
    {

        private readonly minubeDBContext _context;

        public PuntajeController(minubeDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<PuntajeActividad>> PostPuntaje(PuntajeActividad puntaje)
        {
            var puntuacion = new PuntajeActividad
            {
                Puntaje = puntaje.Puntaje,
            
            };

            _context.PuntajeActividades.Add(puntaje);
            _context.SaveChanges();
            return puntaje;
        }
    }
}
