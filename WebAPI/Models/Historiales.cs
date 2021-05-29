using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Historiales
    {
        public int IdHistorial { get; set; }
        public int IdUsuario { get; set; }
        public int IdCurso { get; set; }

        public virtual Cursos IdCursoNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
