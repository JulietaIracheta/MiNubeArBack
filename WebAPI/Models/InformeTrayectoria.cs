using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class InformeTrayectoria
    {
        public int Id { get; set; }
        public int Año { get; set; }
        public int IdEstudiante { get; set; }
        public string Curso { get; set; }
        public string Institucion { get; set; }
        public string Informe { get; set; }
        public string Matematica { get; set; }
        public string Lengua { get; set; }
        public string Sociales { get; set; }
        public string Naturales { get; set; }
        public decimal Promedio { get; set; }

    }
}
