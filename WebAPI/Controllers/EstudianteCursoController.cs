using System.Collections.Generic;
using System.Linq;
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
    public class EstudianteCursoController : Controller
    {
        private readonly minubeDBContext _context;
        public EstudianteCursoController(minubeDBContext context)
        {
            _context = context;

        }

        [HttpPost]
        public async Task<ActionResult<List<EstudianteCurso>>> PostEstudianteCurso(EstudianteCursoDto estudianteCurso)
        {

            EstudianteCurso[] estudianteCursoList = new EstudianteCurso[estudianteCurso.IdUsuario.Length];
            for (int i = 0; i < estudianteCurso.IdUsuario.Length; i++)
            {
                var IdEstudiante = estudianteCurso.IdUsuario[i];
                estudianteCursoList[i] = new EstudianteCurso { IdCurso = estudianteCurso.IdCurso, IdUsuario = IdEstudiante };
            }
            foreach (var item in estudianteCursoList)
            {
                if (!UsuarioExists(item.IdUsuario))
                    _context.EstudianteCurso.Add(item);
            }
            
                await _context.SaveChangesAsync();
                return Ok();
            
        }

        private bool UsuarioExists(int id)
        {
            return _context.EstudianteCurso.Any(e => e.IdUsuario == id);
        }
    }
}
