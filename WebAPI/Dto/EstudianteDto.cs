using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dto
{
    public class EstudianteDto
    {
        public int IdPersona { get; set; }
        public string Avatar { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
