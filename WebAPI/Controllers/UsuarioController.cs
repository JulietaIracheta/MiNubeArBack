using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioDBContext _context;
        private readonly JwtService _jwtService;
       
        public UsuarioController(UsuarioDBContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
            
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/usuario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            usuario.id = id;

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuario
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            
            var user = new Usuario
            {
                rol = usuario.rol,
                nombre = usuario.nombre,
                apellido = usuario.apellido,
                email = usuario.email,
                password = BCrypt.Net.BCrypt.HashPassword(usuario.password),
                edad = usuario.edad
            };

            _context.Usuarios.Add(user);

            if (!EmailExists(user.email))
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUsuario", new { id = usuario.id }, usuario);
            }
            else
            {
                return BadRequest(new { message = "Email ya existe en Base de Datos" });
            }
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            var user = await _context.Usuarios.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.id == id);
        }

        private bool EmailExists(string email)
        {
            return _context.Usuarios.Any(e => e.email == email);
        }


        [HttpPost("login")]
        public IActionResult Login(Usuario usuario)
        {
            var user = _context.Usuarios.FirstOrDefault(x => x.email == usuario.email);

            if (user == null) return BadRequest(new { message = "Usuario invalido" });
            
            if(!BCrypt.Net.BCrypt.Verify(usuario.password, user.password))
            {
                return BadRequest(new { message = "Usuario invalido" });
            }

            var jwt = _jwtService.Generate(user.id);
            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            }) ;
            
            return Ok(new { 
                message = "sucess" });
        }

        [HttpGet("user")]
        public IActionResult Usuario()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = _context.Usuarios.FirstOrDefault(x => x.id == userId);
                return Ok(user);

            }
            catch (Exception _)
            {
                return Unauthorized();
            }

        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok(new
            {
                message = "sucess"
            });
        }

    }
}
