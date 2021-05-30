using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class RolInstitucion
    {
        public int IdRolInstitucion { get; set; }
        public int IdRol { get; set; }
        public int IdInstitucion { get; set; }

        public virtual Instituciones IdInstitucionNavigation { get; set; }
        public virtual Roles IdRolNavigation { get; set; }
    }
}
