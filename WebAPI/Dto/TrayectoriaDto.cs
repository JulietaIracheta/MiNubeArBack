using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dto
{
    public class TrayectoriaDto
    {
        public string Informe { get; set; }
        public string Curso { get; set; }
        public string Institucion { get; set; }
        public  List<MateriaCalificacionDto> MateriaCalificacion { get; set; }
        public int Año { get; set; }
    }
}
