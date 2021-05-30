using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Instituciones
    {
        public Instituciones()
        {
            InstitucionCurso = new HashSet<InstitucionCurso>();
            InstitucionDocente = new HashSet<InstitucionDocente>();
            InstitucionEstudiante = new HashSet<InstitucionEstudiante>();
            InstitucionMateria = new HashSet<InstitucionMateria>();
            InstitucionTutor = new HashSet<InstitucionTutor>();
            RolInstitucion = new HashSet<RolInstitucion>();
        }

        public int IdInstitucion { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }

        public virtual ICollection<InstitucionCurso> InstitucionCurso { get; set; }
        public virtual ICollection<InstitucionDocente> InstitucionDocente { get; set; }
        public virtual ICollection<InstitucionEstudiante> InstitucionEstudiante { get; set; }
        public virtual ICollection<InstitucionMateria> InstitucionMateria { get; set; }
        public virtual ICollection<InstitucionTutor> InstitucionTutor { get; set; }
        public virtual ICollection<RolInstitucion> RolInstitucion { get; set; }
    }
}
