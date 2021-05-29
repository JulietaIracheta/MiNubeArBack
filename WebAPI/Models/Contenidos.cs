using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Contenidos
    {
        public Contenidos()
        {
            Comentarios = new HashSet<Comentarios>();
            ContenidoMateriaCurso = new HashSet<ContenidoMateriaCurso>();
        }

        public int IdContenido { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Unidad { get; set; }

        public virtual ICollection<Comentarios> Comentarios { get; set; }
        public virtual ICollection<ContenidoMateriaCurso> ContenidoMateriaCurso { get; set; }
    }
}
