using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Dto;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContenidoController : ControllerBase
    {
        private readonly minubeDBContext _context;
        private ContenidoRepository contenidoRepository;
        private readonly IHostingEnvironment _env;

        public ContenidoController(minubeDBContext context, IHostingEnvironment env)
        {
            _context = context;
            contenidoRepository = new ContenidoRepository(context);
            _env = env;
        }

        [HttpPost("crearContenido")]
        public async Task<ActionResult<Contenidos>> CrearContenido(ContenidoDto contenido)
        {
            return contenidoRepository.Crear(contenido);
        }
        [HttpPost("cargarVideo")]
        public async Task<ActionResult> Cargarvideo([FromForm]IFormFile file)
        {
            if (file == null) return BadRequest();
            
            FileHelper.GuardarVideo(_env.ContentRootPath,file);
            
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<Contenidos>> GetContenidoById(int id)
        {
            return contenidoRepository.GetById(id);
        }
        
        [HttpGet("getContenidoByMateria/{id}")]
        public async Task<ActionResult<Contenidos>> GetContenidoByMateria(int id)
        {
            return contenidoRepository.GetById(id);
        }
    }
}
