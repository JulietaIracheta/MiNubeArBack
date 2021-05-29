using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class CursoDocente
    {
        public int IdCursoDocente { get; set; }
        public int IdCurso { get; set; }
        public int IdDocente { get; set; }

        public virtual Cursos IdCursoNavigation { get; set; }
        public virtual Usuarios IdDocenteNavigation { get; set; }
    }
}
