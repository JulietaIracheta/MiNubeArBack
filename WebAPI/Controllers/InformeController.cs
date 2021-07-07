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
    public class InformeController : ControllerBase
    {
        private readonly minubeDBContext _context;
        private InformeRepository InformeRepository;
        private readonly IHostingEnvironment _env;
        private readonly JwtService _jwtService;

        public InformeController(minubeDBContext context, IHostingEnvironment env, JwtService jwtService)
        {
            _context = context;
            InformeRepository = new InformeRepository(context);
            _env = env;
            _jwtService = jwtService;
        }

        [HttpPost("crearInforme")]
        public async Task<ActionResult<Informes>> CrearInforme([FromForm] InformeDto Informe)
        {
            return InformeRepository.Crear(Informe, _env.ContentRootPath);
        }
        [HttpPost("cargarInforme")]
        public async Task<ActionResult> CargarInforme([FromForm] FileModel file)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "informes", file.Informe);
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                file.FormFile.CopyTo(stream);
            }

            var informes = new Informes
            {
                IdUsuario = file.IdUsuario,
                Informe = file.Informe,
                IdCurso = 1,
                Año = file.Año
            };

            _context.Informes.Add(informes);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);

        }


        [HttpGet]
        public async Task<ActionResult<Informes>> GetInformeById(int id)
        {
            return InformeRepository.GetById(id);
        }

        [HttpGet("getInformeByEstudiante/{id}")]
        public async Task<IQueryable<string>> GetInformeByEstudiante()
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtService.Verify(jwt);

            var userId = Convert.ToInt32(token.Issuer);

            return InformeRepository.GetByEstudianteId(userId);
        }

        [HttpGet("getInformeTrayectoria/{anio}")]
        public async Task<IQueryable<string>> GetInformeTrayectoria(int anio)
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtService.Verify(jwt);

            var userId = Convert.ToInt32(token.Issuer);

            return InformeRepository.GetInformeTrayectoria(userId, anio);
        }
    }
}
