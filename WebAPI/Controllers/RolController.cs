using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly minubeDBContext _context;
        private readonly JwtService _jwtService;

        public RolController(minubeDBContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;

        }
        
        [HttpGet("getRolByUsuario")]
        public int GetRol()
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtService.Verify(jwt);

            var userId = Convert.ToInt32(token.Issuer);
            return _context.UsuarioRol.First(ur => ur.IdUsuario == userId).IdRol;
        }
    }
}
