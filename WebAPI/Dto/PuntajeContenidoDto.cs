using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dto
{
    public class PuntajeContenidoDto
    {
        public int IdPuntajeContenido { get; set; }
        public int IdContenido { get; set; }
        public int Puntaje { get; set; }
        public string Jwt { get; set; }
    }
}
