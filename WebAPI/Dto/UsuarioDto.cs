namespace WebAPI.Dto
{
    public class UsuarioDto
    {
        public int IdUsuario { get; set; }
        public string UsuarioNombre { get; set; }
        public PersonaDto Persona { get; set; }
    }
}
