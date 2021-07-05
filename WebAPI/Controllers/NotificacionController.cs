using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebAPI.Data;
using WebAPI.Dto;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class NotificacionController : Controller
    {
        private readonly minubeDBContext _context;
        private readonly JwtService _jwtService;
        private readonly NotificacionRepository _notificacionRepository;

        public NotificacionController(minubeDBContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
            _notificacionRepository = new NotificacionRepository(context);
        }

        [HttpGet("getByUsuario")]
        public List<NotificacionDto> GetNotificacionesByUsuario(string jwt)
        {
            //var jwt = Request.Cookies["jwt"];
            var token = _jwtService.Verify(jwt);
            var id = Convert.ToInt32(token.Issuer);
            return _notificacionRepository.GetNotificacionByUsuario(id);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return _notificacionRepository.Delete(id) ? (ActionResult) Ok() : BadRequest();
        }
    }
}
