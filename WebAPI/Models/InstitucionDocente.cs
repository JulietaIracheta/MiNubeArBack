using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class InstitucionDocente
    {
        public int IdInstitucionDocente { get; set; }
        public int IdInstitucion { get; set; }
        public int IdDocente { get; set; }

        public virtual Usuarios IdDocenteNavigation { get; set; }
        public virtual Instituciones IdInstitucionNavigation { get; set; }
    }
}
