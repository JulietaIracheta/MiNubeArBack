using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class TutorEstudiante
    {
        public int IdTutorEstudiante { get; set; }
        public int IdUsuarioTutor { get; set; }
        public int IdUsuarioEstudiante { get; set; }

        public virtual Usuarios IdUsuarioEstudianteNavigation { get; set; }
        public virtual Usuarios IdUsuarioTutorNavigation { get; set; }
    }
}
