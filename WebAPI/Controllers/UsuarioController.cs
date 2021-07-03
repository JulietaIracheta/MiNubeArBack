using System;
using System.Collections.Generic;
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
    public class UsuarioController : ControllerBase
    {
        private readonly minubeDBContext _context;
        private readonly JwtService _jwtService;
        private readonly PersonaRepository personaRepository;
        private readonly UsuarioRepository usuarioRepository;
        private readonly IHostingEnvironment _env;


        public UsuarioController(minubeDBContext context, JwtService jwtService, IHostingEnvironment env)
        {
            _context = context;
            _jwtService = jwtService;
            personaRepository = new PersonaRepository(context);
            usuarioRepository = new UsuarioRepository(context);
            _env = env;
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
        
        [HttpGet("getCuentaUsuario")]
        public ActionResult<CuentaUsuarioDto> GetCuentaUsuario()
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtService.Verify(jwt);
            var id = Convert.ToInt32(token.Issuer);

            var usuario = _context.Usuarios.Include(u => u.IdPersonaNavigation).First(e => e.IdUsuario == id);

            if (usuario == null) return NotFound();

            return new CuentaUsuarioDto
            {
                IdPersona = usuario.IdPersona.GetValueOrDefault(),
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.IdPersonaNavigation.Nombre,
                Apellido = usuario.IdPersonaNavigation.Apellido,
                Email = usuario.IdPersonaNavigation.Email,
                UsuarioNombre = usuario.UsuarioNombre,
                Telefono = usuario.IdPersonaNavigation.Telefono,
                Password = string.Empty,
                Avatar = usuario.Avatar
            };
        }
        
        [HttpPost("actualizarCuentaUsuario")]
        public ActionResult  ActualizarCuentaUsuario([FromForm]  CuentaUsuarioDto cuentaUsuario)
        {
            var usuario = _context.Usuarios.First(e => e.IdUsuario == cuentaUsuario.IdUsuario);
            var persona = _context.Personas.First(e => e.IdPersona == cuentaUsuario.IdPersona);


            usuario.Avatar = cuentaUsuario.File == null
                ? usuario.Avatar
                : FileHelper.GuardarAvatar(_env.ContentRootPath, cuentaUsuario.File);

            usuario.UsuarioNombre = cuentaUsuario.UsuarioNombre;
            
            if(!string.IsNullOrEmpty(cuentaUsuario.Password))
                usuario.Password = BCrypt.Net.BCrypt.HashPassword(cuentaUsuario.Password);
            usuario.FechaModificacion = DateTime.Now;

            persona.Apellido = cuentaUsuario.Apellido;
            persona.Nombre = cuentaUsuario.Nombre;
            persona.Email = cuentaUsuario.Email;
            persona.Telefono = cuentaUsuario.Telefono;
            
            var flag = true;
            
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                flag = false;
            }

            return flag ? (ActionResult) Ok(usuario.Avatar) : BadRequest();
        }
        [HttpGet]
        public List<UsuarioDto> GetUsuarios()
        {
            return usuarioRepository.GetAll();
        }

        [HttpGet("estudiantes")]
        public List<PersonaDto> GetEstudiantes()
        {
            return usuarioRepository.GetEstudiantes();
        }

 
        [HttpGet("getEstudiantesDeUnTutor/{id}")]
        public List<Usuarios> getEstudiantesDeUnTutor(int id)
        {
            var estudiante = _context.TutorEstudiante.Where(x => x.IdUsuarioTutor == id).Select(x => x.IdUsuarioEstudianteNavigation).ToList();
            return estudiante;
        }

        [HttpGet("getEstudiantes/")]
        public List<Usuarios> getEstudiantes()
        {
            var estudiantes = _context.UsuarioRol.Where( row => row.IdRol == 1).Select( x => x.IdUsuarioNavigation ).ToList();
            return estudiantes;
        }

        // PUT: api/usuario/5 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioUpdateDto usuario)
        {
            try
            {
                switch(usuario.Rol){
                    case "Docente":
                        usuarioRepository.UpdateDocente(id,usuario);
                        break;
                    case "Estudiante":
                        usuarioRepository.UpdateEstudiante(id,usuario);
                        break;
                    case "Tutor":
                        usuarioRepository.UpdateTutor(id,usuario);
                        break;
                    default:
                        break;
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Problema al intentar modificar al usuario " + usuario.Nombre });
            }
        }

        // POST: api/Usuario
        [HttpPost]
        public async Task<ActionResult<Usuarios>> PostUsuario(PersonaDto usuario)
        {
            try
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
                  
                    InstitucionEstudiante[] institucionEstudianteList = new InstitucionEstudiante[usuario.IdInstitucion.Length] ;
                    // recorro el array de usuarioIdInstitucion
                    for (int i = 0; i < usuario.IdInstitucion.Length; i++)
                    {
                        var idInstitucion = usuario.IdInstitucion[i];                                          
                        institucionEstudianteList[i] = new InstitucionEstudiante { IdInstitucion = idInstitucion, IdUsuarioNavigation = user };
                    }
                    foreach (var item in institucionEstudianteList){
                        _context.InstitucionEstudiante.Add(item);
                    }

                }
                if (usuario.RolId == "2")
                {

                    InstitucionDocente[] institucionDocenteList = new InstitucionDocente[usuario.IdInstitucion.Length] ;
                    var institucionDocente =  new InstitucionDocente();
                    // recorro el array de usuarioIdInstitucion
                    for (int i = 0; i < usuario.IdInstitucion.Length; i++)
                    {
                        var idInstitucion = usuario.IdInstitucion[i];
                        institucionDocenteList[i] = new InstitucionDocente { IdInstitucion = idInstitucion, IdDocenteNavigation = user };
                    }
                    foreach (var item in institucionDocenteList){
                        _context.InstitucionDocente.Add(item);
                    }
                }

                if (usuario.RolId == "3")
                {
                    TutorEstudiante[] tutorEstudianteList = new TutorEstudiante[usuario.IdEstudiantes.Length] ;
                    // recorro el array de usuarioIdIEstudiantes
                    for (int i = 0; i < usuario.IdEstudiantes.Length; i++)
                    {
                        var idEstudiante = usuario.IdEstudiantes[i];
                        tutorEstudianteList[i] = new TutorEstudiante { IdUsuarioEstudiante = idEstudiante, IdUsuarioTutorNavigation = user };
                    }
                    foreach (var item in tutorEstudianteList){
                        _context.TutorEstudiante.Add(item);
                    }
                }

                _context.Personas.Add(persona);
                _context.Usuarios.Add(user);
                _context.UsuarioRol.Add(usuarioRol);

                if (!EmailExists(user.UsuarioNombre))
                {
                    await _context.SaveChangesAsync();
                    // _context.Personas.FirstOrDefault(item => item.IdPersona == usuario.IdPersona);
                    var usuario_aux = _context.Usuarios.FirstOrDefault(item => item.UsuarioNombre == usuario.Email );
                    usuario.IdUsuario = usuario_aux.IdUsuario;
                    return CreatedAtAction("GetUsuario", new { id = user.IdUsuario }, usuario);
                }
                else
                {
                    return CreatedAtAction("GetUsuario", new { id = user.IdUsuario }, new Personas {Email = ""});
                    // return BadRequest(new { message = "Email ya existe en Base de Datos" });
                }
            }
            catch (Exception e)
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuarios))]
        public ActionResult<PersonaDto> Login(Usuarios usuario)
        {
            var user = _context.Usuarios.Include(u => u.IdPersonaNavigation)
                .FirstOrDefault(x => x.IdPersonaNavigation.Email == usuario.UsuarioNombre);

            if (user == null) return BadRequest(new { message = "Usuario invalido" });
            
            if (!BCrypt.Net.BCrypt.Verify(usuario.Password, user.Password))
            {
                return BadRequest(new { message = "Usuario invalido" });
            }
            var jwt = _jwtService.Generate(user.IdUsuario);
            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = false
            }) ;

            return new PersonaDto
            {
                Apellido = user.IdPersonaNavigation.Apellido, Nombre = user.IdPersonaNavigation.Nombre,
                Avatar = user.Avatar
            };
        }
        
        
        
        [HttpPost("loginGoogle")]
        public ActionResult<PersonaDto> LoginGoogle(string email)
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
                HttpOnly = false
            });

            return new PersonaDto
                {Apellido = user.IdPersonaNavigation.Apellido, Nombre = user.IdPersonaNavigation.Nombre};
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

        [HttpGet("materias")]
        public ActionResult<EstudianteMateriasDto> GetMaterias(string email)
        {
            List<EstudianteMateriasDto> materias = usuarioRepository.GetMaterias(email);

            if (materias.Count() > 0)
            {
                return Ok(materias);
            }

            return Ok(new { message = "sin materias"});
        }

        [HttpPost("modificarPassword")]
        public async Task<ActionResult<Usuarios>> ModificarPassword(Usuarios user)
        {
            var usuario = _context.Usuarios.First(x => x.UsuarioNombre == user.UsuarioNombre);

            usuario.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _context.SaveChangesAsync();
            return usuario;
          
        }

        [HttpGet("getUsuarioChatEstudiante")]
        public string ObtenerUsuarioChat()
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtService.Verify(jwt);
            var userId = Convert.ToInt32(token.Issuer);
            
            return usuarioRepository.ObtenerUsuarioChat(userId);
        }
        [HttpGet("getChatsDocente")]
        public List<string> ObtenerChatsDocente()
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtService.Verify(jwt);
            var userId = Convert.ToInt32(token.Issuer);
            
            return usuarioRepository.ObtenerChatsDocente(userId);
        }
    }
}
