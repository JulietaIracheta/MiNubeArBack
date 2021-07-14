using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public int Año { get; set; }
        public int IdUsuario { get; set; }
        public int IdCurso { get; set; }
        public string Informe { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
