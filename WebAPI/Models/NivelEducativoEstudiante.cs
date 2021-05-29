using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class NivelEducativoEstudiante
    {
        public int IdNivelEducativoEstudiante { get; set; }
        public int IdNivelEducativo { get; set; }
        public int IdUsuarioEstudiante { get; set; }

        public virtual NivelEducativo IdNivelEducativoNavigation { get; set; }
        public virtual Usuarios IdUsuarioEstudianteNavigation { get; set; }
    }
}
