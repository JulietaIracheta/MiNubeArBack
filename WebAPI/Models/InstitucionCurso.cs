using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class InstitucionCurso
    {
        public int IdInstitucionCurso { get; set; }
        public int IdInstitucion { get; set; }
        public int IdCurso { get; set; }

        public virtual Cursos IdCursoNavigation { get; set; }
        public virtual Instituciones IdInstitucionNavigation { get; set; }
    }
}
