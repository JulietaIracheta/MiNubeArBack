using System;

namespace WebAPI.Models
{
    public partial class PuntajeContenido
    {
        public int IdPuntajeContenido { get; set; }
        public int IdContenido { get; set; }
        public int IdEstudiante { get; set; }
        public DateTime Fecha { get; set; }
        public int Puntaje { get; set; }

        public virtual Contenidos IdContenidoNavigation { get; set; }
        public virtual Usuarios IdEstudianteNavigation { get; set; }
    }
}
