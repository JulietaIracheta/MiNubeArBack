using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class MateriaCurso
    {
        public MateriaCurso()
        {
            ContenidoMateriaCurso = new HashSet<ContenidoMateriaCurso>();
        }

        public int IdMateriaCurso { get; set; }
        public int IdMateria { get; set; }
        public int IdCurso { get; set; }

        public virtual Cursos IdCursoNavigation { get; set; }
        public virtual Materias IdMateriaNavigation { get; set; }
        public virtual ICollection<ContenidoMateriaCurso> ContenidoMateriaCurso { get; set; }
    }
}
