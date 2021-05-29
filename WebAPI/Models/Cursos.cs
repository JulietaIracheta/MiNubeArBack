using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Cursos
    {
        public Cursos()
        {
            ActividadCurso = new HashSet<ActividadCurso>();
            CursoDocente = new HashSet<CursoDocente>();
            EstudianteCurso = new HashSet<EstudianteCurso>();
            Evento = new HashSet<Evento>();
            Historiales = new HashSet<Historiales>();
            Informes = new HashSet<Informes>();
            InstitucionCurso = new HashSet<InstitucionCurso>();
            MateriaCurso = new HashSet<MateriaCurso>();
        }

        public int IdCurso { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<ActividadCurso> ActividadCurso { get; set; }
        public virtual ICollection<CursoDocente> CursoDocente { get; set; }
        public virtual ICollection<EstudianteCurso> EstudianteCurso { get; set; }
        public virtual ICollection<Evento> Evento { get; set; }
        public virtual ICollection<Historiales> Historiales { get; set; }
        public virtual ICollection<Informes> Informes { get; set; }
        public virtual ICollection<InstitucionCurso> InstitucionCurso { get; set; }
        public virtual ICollection<MateriaCurso> MateriaCurso { get; set; }
    }
}
