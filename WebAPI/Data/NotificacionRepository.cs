using System.Collections.Generic;
using System.Linq;
using WebAPI.Dto;
using WebAPI.Enums;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class NotificacionRepository
    {
        private readonly minubeDBContext _context;

        public NotificacionRepository(minubeDBContext context)
        {
            _context = context;
        }

        public List<NotificacionDto> GetNotificacionByUsuario(int idDestinatario)
        {
            return _context.Notificacion.OrderByDescending(n => n.IdNotificacion)
                .Where(n => n.IdDestinatario == idDestinatario).Select(n=>new NotificacionDto
                {
                    IdDestinatario = n.IdDestinatario,
                    Descripcion = n.Descripcion,
                    IdNotificacion = n.IdNotificacion,
                    Fecha = n.Fecha,
                    IdDestinatarioNavigation = n.IdDestinatarioNavigation,
                    Mensaje = n.Mensaje,
                    TipoNotificacion = n.TipoNotificacion,
                    UrlTipoNotificacion = NotificacionUrlHelper.FormatterUrlNotificacion(n.TipoNotificacion)
                }).ToList();
        }

        public bool Delete(int id)
        {
            var notificacion = _context.Notificacion.FirstOrDefault(n => n.IdNotificacion == id);
            if (notificacion == null) return false;
            _context.Notificacion.Remove(notificacion);
            _context.SaveChanges();
            return true;

        }
    }
}
