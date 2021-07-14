using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dto
{
    public class InformeDto
    {
        public int Id { get; set; }
        public int Año { get; set; }
        public int IdUsuario { get; set; }
        public int IdCurso { get; set; }
        public IFormFile file { get; set; }
        public string Informe { get; set; }
    }
}
