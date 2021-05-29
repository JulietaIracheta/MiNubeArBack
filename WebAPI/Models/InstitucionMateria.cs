using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class InstitucionMateria
    {
        public int IdInstitucionMateria { get; set; }
        public int IdInstitucion { get; set; }
        public int IdMateria { get; set; }

        public virtual Instituciones IdInstitucionNavigation { get; set; }
        public virtual Materias IdMateriaNavigation { get; set; }
    }
}
