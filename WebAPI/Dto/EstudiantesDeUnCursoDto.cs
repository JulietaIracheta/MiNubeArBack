namespace WebAPI.Dto
{
    public class EstudiantesDeUnCursoDto
    {
        public int IdCurso { get; set; }
        public int IdInstitucion { get; set; }
        public int[] IdEstudiantes { get; set; }
    }
}
