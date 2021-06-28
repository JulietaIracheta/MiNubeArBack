using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class PuntajeActividad

    {
        public int IdEstudiante { get; set; }
        public int IdMateria{ get; set; }
        public int? Puntaje{ get; set; }
        public int IdActividad{ get; set; }
        public int IdActividadEstudianteMateriaPuntaje{ get; set; }
        public int IdCurso { get; set; }

        public virtual Actividades IdActividadPuntajeNavigation { get; set; }
        public virtual Cursos IdCursoPuntajeNavigation { get; set; }
        public virtual Materias IdMateriaPuntajeNavigation { get; set; }
        public virtual Usuarios IdUsuarioPuntajeNavigation { get; set; }

    }
}
