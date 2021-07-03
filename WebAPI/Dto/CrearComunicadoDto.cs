using System;
using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Dto
{
    public class CrearComunicadoDto
    {
        public int IdCurso { get; set; }
        public int IdComunicado { get; set; }
        public int IdDocente { get; set; }
        public List<int> IdUsuario { get; set; }
        public string Descripcion { get; set; }
    }
}
