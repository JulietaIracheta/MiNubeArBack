using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Comunicados = new HashSet<Comunicados>();
            CursoDocente = new HashSet<CursoDocente>();
            EstudianteCurso = new HashSet<EstudianteCurso>();
            Historiales = new HashSet<Historiales>();
            Informes = new HashSet<Informes>();
            InstitucionDocente = new HashSet<InstitucionDocente>();
            InstitucionEstudiante = new HashSet<InstitucionEstudiante>();
            InstitucionTutor = new HashSet<InstitucionTutor>();
            MateriaDocente = new HashSet<MateriaDocente>();
            MateriaEstudiante = new HashSet<MateriaEstudiante>();
            NivelEducativoEstudiante = new HashSet<NivelEducativoEstudiante>();
            TutorEstudianteIdUsuarioEstudianteNavigation = new HashSet<TutorEstudiante>();
            TutorEstudianteIdUsuarioTutorNavigation = new HashSet<TutorEstudiante>();
            UsuarioRol = new HashSet<UsuarioRol>();
        }

        public int IdUsuario { get; set; }
        public int? IdPersona { get; set; }
        public string UsuarioNombre { get; set; }
        public string Password { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaEliminacionLogico { get; set; }

        public virtual Personas IdPersonaNavigation { get; set; }
        public virtual ICollection<Comunicados> Comunicados { get; set; }
        public virtual ICollection<CursoDocente> CursoDocente { get; set; }
        public virtual ICollection<EstudianteCurso> EstudianteCurso { get; set; }
        public virtual ICollection<Historiales> Historiales { get; set; }
        public virtual ICollection<Informes> Informes { get; set; }
        public virtual ICollection<InstitucionDocente> InstitucionDocente { get; set; }
        public virtual ICollection<InstitucionEstudiante> InstitucionEstudiante { get; set; }
        public virtual ICollection<InstitucionTutor> InstitucionTutor { get; set; }
        public virtual ICollection<MateriaDocente> MateriaDocente { get; set; }
        public virtual ICollection<MateriaEstudiante> MateriaEstudiante { get; set; }
        public virtual ICollection<NivelEducativoEstudiante> NivelEducativoEstudiante { get; set; }
        public virtual ICollection<TutorEstudiante> TutorEstudianteIdUsuarioEstudianteNavigation { get; set; }
        public virtual ICollection<TutorEstudiante> TutorEstudianteIdUsuarioTutorNavigation { get; set; }
        public virtual ICollection<UsuarioRol> UsuarioRol { get; set; }
        public virtual ICollection<Boletin> Boletin { get; set; }
    }
}
