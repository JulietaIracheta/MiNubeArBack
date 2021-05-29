using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class UsuarioRol
    {
        public int IdUsuarioRol { get; set; }
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }

        public virtual Roles IdRolNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
