using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dto
{
    public class PromedioActividadContenidoDto
    {
        public int ActividadResuelta { get; set; }
        public int ContenidoVisto { get; set; }
        public string ContenidoResumen { get; set; }
        public string ActividadResumen { get; set; }
    }
}
