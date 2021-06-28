﻿using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Materias
    {
        public Materias()
        {
            InstitucionMateria = new HashSet<InstitucionMateria>();
            MateriaCurso = new HashSet<MateriaCurso>();
            MateriaDocente = new HashSet<MateriaDocente>();
            MateriaEstudiante = new HashSet<MateriaEstudiante>();
            PuntajeActividades = new HashSet<PuntajeActividad>();
        }

        public int IdMateria { get; set; }
        public string Nombre { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<InstitucionMateria> InstitucionMateria { get; set; }
        public virtual ICollection<MateriaCurso> MateriaCurso { get; set; }
        public virtual ICollection<MateriaDocente> MateriaDocente { get; set; }
        public virtual ICollection<MateriaEstudiante> MateriaEstudiante { get; set; }
        public virtual ICollection<PuntajeActividad> PuntajeActividades { get; set; }
       
    }
}
