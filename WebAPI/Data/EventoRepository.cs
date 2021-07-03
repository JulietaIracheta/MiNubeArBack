using System;
using System.Collections.Generic;
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

            
            var listaEstudiantes=_context.EstudianteCurso.Where(c => c.IdCurso == 1).ToList();
            var listaDeNotificaciones = new List<Notificacion>();

            foreach (var estudiante in listaEstudiantes)
            {
                var tutor = _context.TutorEstudiante.FirstOrDefault(e => e.IdUsuarioEstudiante == estudiante.IdUsuario)?.IdUsuarioTutor;
                listaDeNotificaciones.Add(new Notificacion
                {
                    Descripcion = "Nuevo Evento",
                    Fecha = DateTime.Now,
                    IdDestinatario = estudiante.IdUsuario,
                    IdNotificacion = 0,
                    Mensaje = $"Se ha creado un nuevo evento {DateTime.Now:g}",
                    TipoNotificacion = (int) TipoNotificacion.Evento
                });
                if(tutor.HasValue)
                    listaDeNotificaciones.Add(new Notificacion
                    {
                        Descripcion = "Nuevo Evento",
                        Fecha = DateTime.Now,
                        IdDestinatario = tutor.Value,
                        IdNotificacion = 0,
                        Mensaje = $"Se ha creado un nuevo evento {DateTime.Now:g}",
                        TipoNotificacion = (int)TipoNotificacion.Evento
                    });
            }

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
