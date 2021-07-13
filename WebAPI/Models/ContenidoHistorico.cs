using System;
namespace WebAPI.Models
{
    public partial class ContenidoHistorico
    {
        public int IdContenidoHistorico { get; set; }
        public int IdContenido { get; set; }

        public virtual Contenidos IdContenidoNavigation { get; set; }
    }
}
