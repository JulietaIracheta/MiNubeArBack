using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Evento
    {
        public int IdEvento { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime Start { get; set; }
        public int IdCurso { get; set; }

        public virtual Cursos IdCursoNavigation { get; set; }
    }
}
