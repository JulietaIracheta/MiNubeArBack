using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dto;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComunicadoController : Controller
    {
        private readonly minubeDBContext _context;
        private readonly JwtService _jwtService;
        private ComunicadoRepository comunicadoRepository;
        protected readonly IHubContext<NotificacionesHub> _notificacionesHub;
        
        public ComunicadoController(minubeDBContext context, JwtService jwtService, IHubContext<NotificacionesHub> notificacionesHub)
        {
            _context = context;
            _notificacionesHub = notificacionesHub;
            comunicadoRepository = new ComunicadoRepository(context, _notificacionesHub);
            _jwtService = jwtService;
        }

        [HttpPost]
        public async Task<ActionResult<List<ComunicadosDocenteDto>>> CrearComunicado(CrearComunicadoDto comunicado)
        {
            return comunicadoRepository.Crear(comunicado);
        }

        [HttpGet("getComunicados")]
        public List<ComunicadosDocenteDto> GetComunicados()
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtService.Verify(jwt);
            var id = Convert.ToInt32(token.Issuer);
            return comunicadoRepository.GetAll(id);
        }

        [HttpGet("getComunicadosByEstudiante")]
        public List<ComunicadoDto> GetComunicadosDeEstudiante()
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtService.Verify(jwt);
            var id = Convert.ToInt32(token.Issuer);
            return comunicadoRepository.GetAllByEstudiante(id);
        }
        [HttpGet("getComunicadosByTutor")]
        public List<ComunicadoDto> GetComunicadosDeTutor()
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtService.Verify(jwt);
            var id = Convert.ToInt32(token.Issuer);
            return comunicadoRepository.GetAllComunicadosDeTutor(id);
        }
    }
}