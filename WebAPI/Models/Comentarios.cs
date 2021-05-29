using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Comentarios
    {
        public int IdComentario { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }
        public int IdContenido { get; set; }

        public virtual Contenidos IdContenidoNavigation { get; set; }
    }
}
