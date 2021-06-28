
using System.Collections.Generic;
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
    public class InstitucionCursoController : Controller
    {
        private readonly minubeDBContext _context;
        private IInstitucionCursoRepository _institucionCursoRepository;

        public InstitucionCursoController(minubeDBContext context,IInstitucionCursoRepository institucionCursoRepository)
        {
            _context = context;
            _institucionCursoRepository = institucionCursoRepository;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cursos>>> GetCursos()
        {
            return await _context.Cursos.ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult<List<InstitucionCurso>>> PostInstitucionCurso(InstitucionCursoDto institucion)
        {

            InstitucionCurso[] institucionCursoList = new InstitucionCurso[institucion.IdCurso.Length];
            for (int i = 0; i < institucion.IdCurso.Length; i++)
            {
                var IdCurso = institucion.IdCurso[i];
                institucionCursoList[i] = new InstitucionCurso {  IdCurso = IdCurso, IdInstitucion = institucion.IdInstitucion };
            }
            foreach (var item in institucionCursoList)
            {
                _context.InstitucionCurso.Add(item);
            }

            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
