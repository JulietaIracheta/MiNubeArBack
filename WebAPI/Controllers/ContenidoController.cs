using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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
        public async Task<ActionResult<Contenidos>> CrearContenido([FromForm] ContenidoDto contenido)
        {
            return contenidoRepository.Crear(contenido, _env.ContentRootPath);
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
        public async Task<ActionResult<List<Contenidos>>> GetContenidoByMateria(int id)
        {
            return contenidoRepository.GetByMateriaId(id);
        }
        [HttpDelete]
        public ActionResult Eliminar(int id)
        {
            var flag = true;
            var contenido = _context.Contenidos.Include(e => e.ContenidoMateriaCurso).First(e => e.IdContenido == id);
            var contenidoMateriaCurso = _context.ContenidoMateriaCurso.First(e => e.IdContenido == id);
            var contenidoActividad = _context.Actividades.Include(e=>e.ActividadCurso).First(e => e.IdContenido == id);
            var questionActividad = _context.Questions.First(e => e.ActividadesId == contenidoActividad.IdActividad);
            var answerQuestion = _context.Answers.Where(a => a.QuestionId == questionActividad.Id);
            try
            {
                _context.Answers.RemoveRange(answerQuestion);
                _context.Questions.Remove(questionActividad);
                _context.ActividadCurso.RemoveRange(contenidoActividad.ActividadCurso);
                _context.Actividades.Remove(contenidoActividad);
                _context.ContenidoMateriaCurso.Remove(contenidoMateriaCurso);
                _context.Contenidos.Remove(contenido);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                flag = false;
            }

            return flag ? (ActionResult) Ok() : BadRequest();
        }
    }
}
