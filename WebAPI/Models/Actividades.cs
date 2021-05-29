using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Actividades
    {
        public Actividades()
        {
            ActividadCurso = new HashSet<ActividadCurso>();
        }

        public int IdActividad { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<ActividadCurso> ActividadCurso { get; set; }
    }
}
