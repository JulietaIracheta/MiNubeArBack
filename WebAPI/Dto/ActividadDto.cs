using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dto
{
    public class ActividadDto
    {
        public int IdActividad { get; set; }
        public string Titulo { get; set; }        

        public ActividadDto(int idActividad, string titulo)
        {
            IdActividad = idActividad;
            Titulo = titulo;                        
        }
    }
}
