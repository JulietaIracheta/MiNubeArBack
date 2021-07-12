using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dto
{
    public class ActividadMateriaDto
    {
        public int IdActividad { get; set; }
        public int Unidad { get; set; }
        public string Titulo { get; set; }

        public ActividadMateriaDto(int idActividad, int unidad, string titulo)
        {
            IdActividad = idActividad;
            Unidad = unidad;
            Titulo = titulo;
        }
    }
}
