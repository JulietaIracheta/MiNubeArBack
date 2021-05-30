using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class EstudianteCurso
    {
        public int IdEstudianteCurso { get; set; }
        public int IdUsuario { get; set; }
        public int IdCurso { get; set; }

        public virtual Cursos IdCursoNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
