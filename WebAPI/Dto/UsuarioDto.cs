namespace WebAPI.Dto
{
    public class UsuarioDto
    {
        public int UsuarioId { get; set; }
        public string Email { get; set; }
        public PersonaDto Persona { get; set; }
    }
}
