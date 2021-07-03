namespace WebAPI.Dto
{
    public class ComunicadoDto
    {
        public int IdCurso { get; set; }
        public int IdComunicado { get; set; }
        public int IdDocente { get; set; }
        public string Docente { get; set; }
        public int IdUsuario { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
    }
}
