using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Roles
    {
        public Roles()
        {
            RolInstitucion = new HashSet<RolInstitucion>();
            RolPermiso = new HashSet<RolPermiso>();
            UsuarioRol = new HashSet<UsuarioRol>();
        }

        public int IdRol { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<RolInstitucion> RolInstitucion { get; set; }
        public virtual ICollection<RolPermiso> RolPermiso { get; set; }
        public virtual ICollection<UsuarioRol> UsuarioRol { get; set; }
    }
}
