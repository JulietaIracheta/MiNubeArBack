using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class ActividadMateriaUnidad
    {
        public int IdActividadMateriaUnidad { get; set; }
        public int IdActividad { get; set; }
        public int IdMateria { get; set; }
        public int Unidad { get; set; }
        public string Titulo { get; set; }

        public virtual Actividades IdActividadNavigation { get; set; }
        public virtual Materias IdMateriaNavigation { get; set; }
    }
}
