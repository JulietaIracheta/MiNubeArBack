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
            Questions = new HashSet<Question>();
            PuntajeActividades = new HashSet<PuntajeActividad>();
        }

        public int IdActividad { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Unidad { get; set; }
        public int IdMateria { get; set; }
		public int IdContenido { get; set; }

        public virtual ICollection<ActividadCurso> ActividadCurso { get; set; }
		public virtual Contenidos IdContenidoNavigation { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<PuntajeActividad> PuntajeActividades { get; set; }


    }
}
