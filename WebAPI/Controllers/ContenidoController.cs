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
        private readonly JwtService _jwtService;

        public ContenidoController(minubeDBContext context, IHostingEnvironment env, JwtService jwtService)
        {
            _context = context;
            contenidoRepository = new ContenidoRepository(context);
            _env = env;
            _jwtService = jwtService;

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
        [HttpGet("{id}")]
        public async Task<ActionResult<Contenidos>> GetContenidoById(int id)
        {
            return contenidoRepository.GetById(id);
        }
        
        [HttpGet("getContenidoByMateria/{idMateria}/{idCurso}")]
        public async Task<ActionResult<List<Contenidos>>> GetContenidoByMateria(int idMateria, int idCurso)
        {
            return contenidoRepository.GetByMateriaId(idMateria,idCurso);
        }
        [HttpGet("getContenidoDeEstudiante/{idMateria}")]
        public async Task<ActionResult<List<Contenidos>>> GetContenidoDeEstudiante(int idMateria, string jwt)
        {
            var token = _jwtService.Verify(jwt);
            var userId = Convert.ToInt32(token.Issuer);
            var idCurso=_context.EstudianteCurso.First(e => e.IdUsuario == userId).IdCurso;
            return contenidoRepository.GetByEstudiante(idMateria, idCurso);
        }
        [HttpDelete]
        public ActionResult Eliminar(int id)
        {
            var flag = true;
            var contenido = _context.Contenidos.Include(e => e.ContenidoMateriaCurso).First(e => e.IdContenido == id);
            /*  var contenidoMateriaCurso = _context.ContenidoMateriaCurso.First(e => e.IdContenido == id);
            var contenidoActividad = _context.Actividades.Include(e=>e.ActividadCurso).First(e => e.IdContenido == id);
            var questionActividad = _context.Questions.First(e => e.ActividadesId == contenidoActividad.IdActividad);
            var answerQuestion = _context.Answers.Where(a => a.QuestionId == questionActividad.Id);
            */try
            {
                contenido.FechaBaja = DateTime.Now;
                /*_context.Answers.RemoveRange(answerQuestion);
                _context.Questions.Remove(questionActividad);
                _context.ActividadCurso.RemoveRange(contenidoActividad.ActividadCurso);
                _context.Actividades.Remove(contenidoActividad);
                _context.ContenidoMateriaCurso.Remove(contenidoMateriaCurso);
                //_context.Contenidos.Remove(contenido);*/
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                flag = false;
            }

            return flag ? (ActionResult) Ok() : BadRequest();
        }
        [HttpGet("getContenidosHistoricos")]
        public List<Contenidos> GetContenidosHistoricos(string jwt)
        {
            var token = _jwtService.Verify(jwt);

            var userId = Convert.ToInt32(token.Issuer);
            var listaDeCursos = _context.EstudianteCurso.Where(e => e.IdUsuario == userId).Select(e => e.IdCurso).Distinct().ToList();
            var listaDeContenidos= _context.Contenidos.Include(e => e.ContenidoHistorico).Where(e =>
                    e.ContenidoMateriaCurso.Any(p => listaDeCursos.Contains(p.IdMateriaCursoNavigation.IdCurso)) &&
                    e.Fecha.HasValue && e.Fecha.Value.Year != DateTime.Now.Year)
                .Select(e => e.IdContenido).Distinct().ToList();


            return _context.ContenidoHistorico.Include(e => e.IdContenidoNavigation).ThenInclude(e => e.Actividades)
                .ThenInclude(e => e.Questions).ThenInclude(e => e.Answers).Include(e => e.IdContenidoNavigation)
                .ThenInclude(e => e.ContenidoMateriaCurso).ThenInclude(e => e.IdMateriaCursoNavigation)
                .ThenInclude(e => e.IdMateriaNavigation)
                .Where(e => listaDeContenidos.Contains(e.IdContenido)).OrderBy(e => e.IdContenidoNavigation.Fecha)
                .Select(e => e.IdContenidoNavigation).ToList();
        }
    }
}
