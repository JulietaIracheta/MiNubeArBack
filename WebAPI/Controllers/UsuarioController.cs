using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class UsuarioController : ControllerBase
    {
        private readonly minubeDBContext _context;
        private readonly JwtService _jwtService;
        private readonly UsuarioRepository usuarioRepository;

        public UsuarioController(minubeDBContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
            usuarioRepository = new UsuarioRepository(context);
        }


        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        [HttpGet]
        public List<UsuarioDto> GetUsuarios()
        {
            return usuarioRepository.GetAll();
        }

        // PUT: api/usuario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuarios usuario)
        {
            usuario.IdUsuario = id;

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
        public async Task<ActionResult<Usuarios>> PostUsuario(PersonaDto usuario)
        {
            var persona = new Personas {Apellido = usuario.Apellido, Email = usuario.Email, Nombre = usuario.Nombre, Telefono = usuario.Telefono};

            var user = new Usuarios
            {
                UsuarioNombre = persona.Email,
                IdPersona = usuario.IdPersona,
                Password = BCrypt.Net.BCrypt.HashPassword(usuario.Password),
                IdPersonaNavigation = persona,
                FechaCreacion = DateTime.Now
            };
            var usuarioRol = new UsuarioRol {IdRol = Convert.ToInt32(usuario.RolId), IdUsuarioNavigation = user,};

            if (usuario.RolId == "1")
            {
                var institucionEstudiante = new InstitucionEstudiante { IdInstitucion = usuario.IdInstitucion, IdUsuarioNavigation = user };
                _context.InstitucionEstudiante.Add(institucionEstudiante);

            }
            if (usuario.RolId == "2")
            {
                var institucionDocente = new InstitucionDocente { IdInstitucion = usuario.IdInstitucion, IdDocenteNavigation = user };
                _context.InstitucionDocente.Add(institucionDocente);

            }
            if (usuario.RolId == "3")
            {
                var institucionTutor = new InstitucionTutor { IdInstitucion = usuario.IdInstitucion, IdTutorNavigation = user };
                _context.InstitucionTutor.Add(institucionTutor);
            }
            _context.Personas.Add(persona);
            _context.Usuarios.Add(user);
            _context.UsuarioRol.Add(usuarioRol);

            if (!EmailExists(user.UsuarioNombre))
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUsuario", new { id = user.IdUsuario }, usuario);
            }
            else
            {
                return BadRequest(new { message = "Email ya existe en Base de Datos" });
            }
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuarios>> DeleteUsuario(int id)
        {
            var user = await _context.Usuarios.FindAsync(id);
          
            if (user == null)
            {
                return NotFound();
            }


            user.FechaEliminacionLogico = DateTime.Now;
            _context.Usuarios.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }

        private bool EmailExists(string usuarioNombre)
        {
            return _context.Usuarios.Any(e => e.UsuarioNombre == usuarioNombre);
        }


        [HttpPost("login")]
        public IActionResult Login(Usuarios usuario)
        {
            var user = _context.Usuarios.Include(u=>u.IdPersonaNavigation).FirstOrDefault(x => x.IdPersonaNavigation.Email == usuario.UsuarioNombre);

            if (user == null) return BadRequest(new { message = "Usuario invalido" });


            if (!BCrypt.Net.BCrypt.Verify(usuario.Password, user.Password))
            {
                return BadRequest(new { message = "Usuario invalido" });
            }
            var jwt = _jwtService.Generate(user.IdUsuario);
            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            }) ;
            
            return Ok(new { 
                message = "sucess" });
        }
        [HttpPost("loginGoogle")]
        public IActionResult LoginGoogle(string email)
        {
            var user = _context.Usuarios.Include(u => u.IdPersonaNavigation)
                .Include(u=>u.UsuarioRol)
                .FirstOrDefault(x => x.IdPersonaNavigation.Email == email);

            if (user == null) return BadRequest(new { message = "Usuario invalido" });

            /*if (!BCrypt.Net.BCrypt.Verify(email, user.Password))
            {
                return BadRequest(new { message = "Usuario invalido" });
            }*/

            var jwt = _jwtService.Generate(user.IdUsuario);
            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok(new
            {
                message = "sucess"
            });
        }

        [HttpGet("user")]
        public IActionResult Usuario()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);

                var userId = Convert.ToInt32(token.Issuer);

                var user = _context.Usuarios.Include(u=>u.IdPersonaNavigation).FirstOrDefault(x => x.IdUsuario == userId);
                return Ok(user);

            }
            catch (Exception e)
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
