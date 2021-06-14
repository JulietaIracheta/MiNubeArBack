using System;

namespace WebAPI.Dto
{
    public class PersonaDto
    {
        public int IdPersona { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string UsuarioNombre { get; set; }
        public int Telefono { get; set; }
        public string Rol { get; set; }
        public string RolId { get; set; }
        public string Password { get; set; }
        public int[] IdInstitucion { get; set; }
        public string Avatar { get; set; }

    }
}
