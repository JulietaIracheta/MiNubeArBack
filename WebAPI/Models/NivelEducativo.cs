using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class NivelEducativo
    {
        public NivelEducativo()
        {
            NivelEducativoEstudiante = new HashSet<NivelEducativoEstudiante>();
        }

        public int IdNivelEducativo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<NivelEducativoEstudiante> NivelEducativoEstudiante { get; set; }
    }
}
