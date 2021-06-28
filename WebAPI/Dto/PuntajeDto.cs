using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dto
{
    public class PuntajeDto
    {
        public int idMateria { get; set; }
        public int idUnidad { get; set; }
        public int idEstudiante { get; set; }
        public double avance { get; set; }
    }
}
