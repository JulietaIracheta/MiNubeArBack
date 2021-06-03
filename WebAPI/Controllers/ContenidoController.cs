using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Dto;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContenidoController : ControllerBase
    {
        private readonly minubeDBContext _context;
        private ContenidoRepository contenidoRepository;
        public ContenidoController(minubeDBContext context)
        {
            _context = context;
            contenidoRepository = new ContenidoRepository(context);
        }

        [HttpPost]
        public async Task<ActionResult<Contenidos>> CrearContenido(ContenidoDto contenido)
        {
            return contenidoRepository.Crear(contenido);
        }
        [HttpGet]
        public async Task<ActionResult<Contenidos>> GetContenidoById(int id)
        {
            return contenidoRepository.GetById(id);
        }
    }
}
