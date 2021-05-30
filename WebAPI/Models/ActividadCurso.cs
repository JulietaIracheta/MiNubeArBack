using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class ActividadCurso
    {
        public int IdActividadCurso { get; set; }
        public int IdActividad { get; set; }
        public int IdCurso { get; set; }

        public virtual Actividades IdActividadNavigation { get; set; }
        public virtual Cursos IdCursoNavigation { get; set; }
    }
}
