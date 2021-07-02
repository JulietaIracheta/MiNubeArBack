using Microsoft.AspNetCore.Http;

namespace WebAPI.Dto
{
    public class CuentaUsuarioDto
    {
        public int IdUsuario { get; set; }
        public int IdPersona { get; set; }
        public string UsuarioNombre { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public IFormFile File { get; set; }
    }
}
