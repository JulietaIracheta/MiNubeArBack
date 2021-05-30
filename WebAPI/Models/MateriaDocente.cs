using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class MateriaDocente
    {
        public int IdMateriaDocente { get; set; }
        public int IdMateria { get; set; }
        public int IdUsuario { get; set; }

        public virtual Materias IdMateriaNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
