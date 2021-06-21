namespace WebAPI.Dto
{
    public class UsuarioUpdateDto
    {
        public int IdPersona { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int[] IdInstitucion { get; set; }
        public string Rol { get; set; }
    }
}
