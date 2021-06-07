using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Dto
{
    public class ComunicadoDto
    {
        public int IdCurso { get; set; }
        public int IdComunicado { get; set; }
        public List<int> IdUsuario { get; set; }
        public string Descripcion { get; set; }
    }
}
