using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class InstitucionEstudiante
    {
        public int IdInstitucionEstudiante { get; set; }
        public int IdInstitucion { get; set; }
        public int IdUsuario { get; set; }

        public virtual Instituciones IdInstitucionNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
