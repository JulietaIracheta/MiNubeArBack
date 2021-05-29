using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Permisos
    {
        public Permisos()
        {
            RolPermiso = new HashSet<RolPermiso>();
        }

        public int IdPermiso { get; set; }
        public string Operacion { get; set; }

        public virtual ICollection<RolPermiso> RolPermiso { get; set; }
    }
}
