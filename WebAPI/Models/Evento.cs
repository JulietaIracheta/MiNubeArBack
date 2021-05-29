using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Evento
    {
        public int IdEvento { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCurso { get; set; }

        public virtual Cursos IdCursoNavigation { get; set; }
    }
}
