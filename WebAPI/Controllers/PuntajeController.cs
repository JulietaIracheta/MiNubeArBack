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
    public class PuntajeController : ControllerBase
    {

        private readonly minubeDBContext _context;
        private readonly JwtService _jwtService;

        public PuntajeController(minubeDBContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

            [HttpPost]
        public async Task<ActionResult<PuntajeContenido>> PostPuntaje(PuntajeContenidoDto puntaje)
        {
            var token = _jwtService.Verify(puntaje.Jwt);
            var userId = Convert.ToInt32(token.Issuer);
            var puntajeContenido = new PuntajeContenido()
            {
                Fecha = DateTime.Now,
                IdContenido = puntaje.IdContenido,
                Puntaje = puntaje.Puntaje,
                IdEstudiante = userId
            };
            
            var contenido = _context.Contenidos.First(e => e.IdContenido == puntajeContenido.IdContenido);
            contenido.Visto = true;
            _context.PuntajeContenido.Add(puntajeContenido);
            _context.SaveChanges();
            return puntajeContenido;
        }
    }
}
