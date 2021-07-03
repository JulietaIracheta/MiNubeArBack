using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Enums;

namespace WebAPI.Helpers
{
    public static class NotificacionUrlHelper
    {
        public static string FormatterUrlNotificacion(int id)
        {
            var url = "";
            switch (id)
            {
                case (int) TipoNotificacion.Comunicado:
                    url = "comunicado";
                    break;
                case (int)TipoNotificacion.Evento:
                    url = "calendario";
                    break;
            }

            return url;
        }
    }
}
