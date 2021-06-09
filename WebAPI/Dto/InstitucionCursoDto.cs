using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dto
{
    public class InstitucionCursoDto
    {
        public int IdInstitucion { get; set; }
        public int IdCurso { get; set; }
        public List<int> IdInstCurso { get; set; }
    }
}
