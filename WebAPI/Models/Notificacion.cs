using System;

namespace WebAPI.Models
{
    public partial class Notificacion
    {
        public int IdNotificacion { get; set; }
        public string Mensaje { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int TipoNotificacion { get; set; }
        public int IdDestinatario { get; set; }

        public virtual Usuarios IdDestinatarioNavigation { get; set; }
    }
}
