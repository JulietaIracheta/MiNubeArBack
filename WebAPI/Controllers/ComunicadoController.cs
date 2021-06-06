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
    public class ComunicadoController : Controller
    {
        private readonly minubeDBContext _context;
        private ComunicadoRepository comunicadoRepository;
        public ComunicadoController(minubeDBContext context)
        {
            _context = context;
            comunicadoRepository = new ComunicadoRepository(context);
        }
        [HttpPost]
        public async Task<ActionResult<Comunicados>> CrearComunicado (ComunicadoDto comunicado)
        {
            return comunicadoRepository.Crear(comunicado);
        }
        [HttpGet("getComunicados")]
        public List<Comunicados> GetComunicados()
        {
            var comunicados = _context.Comunicados;
            
            return comunicados.ToList();
        }
    }
}
