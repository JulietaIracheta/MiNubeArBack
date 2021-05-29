using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class RolPermiso
    {
        public int IdrolPermiso { get; set; }
        public int IdRol { get; set; }
        public int IdPermiso { get; set; }

        public virtual Permisos IdPermisoNavigation { get; set; }
        public virtual Roles IdRolNavigation { get; set; }
    }
}
