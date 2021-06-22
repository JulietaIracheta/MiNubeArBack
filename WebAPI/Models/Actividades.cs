using System;
using System.Collections.Generic;
using WebAPI.Models.Quiz;

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
        public int Unidad { get; set; }

        public virtual ICollection<ActividadCurso> ActividadCurso { get; set; }
      

    }
}
