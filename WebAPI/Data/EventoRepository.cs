using System;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Enums;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface IEventoRepository
    {
        bool EventoExists(int id);
        Task<Boolean> Crear(Evento evento);
    }
    public class EventoRepository : IEventoRepository
    {
        private readonly minubeDBContext _context;

        public EventoRepository(minubeDBContext context)
        {
            _context = context;
        }

        public async Task<Boolean> Crear(Evento evento)
        {
            var user = new Evento {Title = evento.Title, Start = evento.Start, IdCurso = 1, Url = evento.Url};

            var listaDeNotificaciones = _context.EstudianteCurso.Where(c => c.IdCurso == 1).Select(b => new Notificacion
                {
                    Descripcion = "Nuevo Evento",
                    Fecha = DateTime.Now,
                    IdDestinatario = b.IdUsuario,
                    IdNotificacion = 0,
                    Mensaje = $"Se ha creado un nuevo evento {DateTime.Now:g}",
                    TipoNotificacion = (int)TipoNotificacion.Evento
            })
                .ToList();

            _context.Evento.Add(user);
            _context.Notificacion.AddRange(listaDeNotificaciones);

            if (EventoExists(user.IdEvento)) return false;
            
            await _context.SaveChangesAsync();
            return true;

        }
        public bool EventoExists(int id)
        {
            return _context.Evento.Any(e => e.IdEvento == id);
        }
    }
}
