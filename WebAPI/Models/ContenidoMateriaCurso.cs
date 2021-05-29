using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class ContenidoMateriaCurso
    {
        public int IdContenidoMateriaCurso { get; set; }
        public int IdContenido { get; set; }
        public int IdMateriaCurso { get; set; }

        public virtual Contenidos IdContenidoNavigation { get; set; }
        public virtual MateriaCurso IdMateriaCursoNavigation { get; set; }
    }
}
