using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Comunicados
    {
        public int IdComunicado { get; set; }
        public int IdUsuario { get; set; }
        public int IdDocente { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Usuarios IdUsuarioNavigation { get; set; }
        public virtual Usuarios IdDocenteNavigation { get; set; }
    }
}
