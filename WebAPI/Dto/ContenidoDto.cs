using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Dto
{
    public class ContenidoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Unidad { get; set; }
        public List<IFormFile> File { get; set; }
        public string Video { get; set; }
    }
}
