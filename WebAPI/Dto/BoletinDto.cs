using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dto
{
    public class BoletinDto
    {

        public int Año { get; set; }
        public int? IdEstudiante { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Materia { get; set; }
        public decimal T1 { get; set; }
        public decimal T2 { get; set; }
        public decimal T3 { get; set; }
    }
}
