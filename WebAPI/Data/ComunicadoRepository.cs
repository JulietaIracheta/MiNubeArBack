using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using WebAPI.Dto;
using WebAPI.Enums;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface IComunicadoRepository
    {
        Comunicados GetById(int id);
    }

    public class ComunicadoRepository : IComunicadoRepository
    {
        private readonly minubeDBContext _context;
        private UsuarioRepository usuarioRepository;
        private IHubContext<NotificacionesHub> _notificacionesHub;

        public ComunicadoRepository(minubeDBContext context, [NotNull] IHubContext<NotificacionesHub> notificacionesHub)
        {
            _context = context;
            usuarioRepository = new UsuarioRepository(context);
            _notificacionesHub = notificacionesHub;
        }

        public Comunicados GetById(int id)
        {
            return _context.Comunicados.FirstOrDefault(x => x.IdComunicado == id);
        }

        public List<ComunicadosDocenteDto> Crear(CrearComunicadoDto comunicado)
        {
            if (string.IsNullOrEmpty(comunicado.Descripcion)) return null;

            if (!comunicado.IdUsuario.Any())
                return CrearComunicadoMasivo(comunicado);

            var listaDeComunicados = new List<Comunicados>();
            var listaDeNotificaciones = new List<Notificacion>();

            foreach (var usuario in comunicado.IdUsuario)
            {
                var tutor = _context.TutorEstudiante.First(e => e.IdUsuarioEstudiante == usuario).IdUsuarioTutor;
               
                listaDeComunicados.Add(new Comunicados
                {
                    Descripcion = comunicado.Descripcion,
                    IdDocente = comunicado.IdDocente,
                    Fecha = DateTime.Now,
                    IdUsuarioNavigation = usuarioRepository.GetById(usuario),
                    IdUsuario = usuario
                });
                listaDeNotificaciones.Add(new Notificacion
                {
                    Descripcion = "Nuevo comunicado",
                    Fecha = DateTime.Now,
                    IdDestinatario = usuario,
                    IdNotificacion = 0,
                    Mensaje = $"Ha recibido un nuevo comunicado {DateTime.Now:g}",
                    TipoNotificacion = (int) TipoNotificacion.Comunicado
                });
                
                listaDeNotificaciones.Add(new Notificacion
                {
                    Descripcion = "Nuevo comunicado",
                    Fecha = DateTime.Now,
                    IdDestinatario = tutor,
                    IdNotificacion = 0,
                    Mensaje = $"Ha recibido un nuevo comunicado {DateTime.Now:g}",
                    TipoNotificacion = (int)TipoNotificacion.Comunicado
                });
            }

            _context.Comunicados.AddRange(listaDeComunicados);
            _context.Notificacion.AddRange(listaDeNotificaciones);
            _context.SaveChanges();

            return listaDeComunicados.Select(e => new ComunicadosDocenteDto
            {
                Descripcion = e.Descripcion, Fecha = e.Fecha.ToString("g"), IdComunicado = e.IdComunicado,
                NombreApellidoEstudiante = e.IdUsuarioNavigation.IdPersonaNavigation.GetNombreApellido()
            }).ToList();
        }

        public List<ComunicadosDocenteDto> CrearComunicadoMasivo(CrearComunicadoDto comunicado)
        {
            var listaDeComunicados = new List<Comunicados>();
            var listaDeNotificaciones = new List<Notificacion>();

            var estudiantes = _context.EstudianteCurso.Include(e => e.IdUsuarioNavigation)
                .ThenInclude(e => e.IdPersonaNavigation).Where(e => e.IdCurso == comunicado.IdCurso);

            foreach (var estudiante in estudiantes)
            {
                var tutor = _context.TutorEstudiante.First(e => e.IdUsuarioEstudiante == estudiante.IdUsuario).IdUsuarioTutor;

                listaDeComunicados.Add(new Comunicados
                {
                    Descripcion = comunicado.Descripcion,
                    IdDocente = comunicado.IdDocente,
                    Fecha = DateTime.Now,
                    IdUsuarioNavigation = estudiante.IdUsuarioNavigation,
                    IdUsuario = estudiante.IdUsuario
                });
                listaDeNotificaciones.Add(new Notificacion
                {
                    Descripcion = "Nuevo Comunicado",
                    Fecha = DateTime.Now,
                    IdDestinatario = estudiante.IdUsuario,
                    IdNotificacion = 0,
                    Mensaje = $"Ha recibido un nuevo comunicado {DateTime.Now:g}",
                    TipoNotificacion = (int)TipoNotificacion.Comunicado
                });
                listaDeNotificaciones.Add(new Notificacion
                {
                    Descripcion = "Nuevo comunicado",
                    Fecha = DateTime.Now,
                    IdDestinatario = tutor,
                    IdNotificacion = 0,
                    Mensaje = $"Ha recibido un nuevo comunicado {DateTime.Now:g}",
                    TipoNotificacion = (int)TipoNotificacion.Comunicado
                });
            }

            _context.Comunicados.AddRange(listaDeComunicados);
            _context.Notificacion.AddRange(listaDeNotificaciones);
            _context.SaveChanges();

            return listaDeComunicados.Select(c => new ComunicadosDocenteDto
            {
                Descripcion = c.Descripcion, Fecha = c.Fecha.ToString("g"), IdComunicado = c.IdComunicado,
                NombreApellidoEstudiante = c.IdUsuarioNavigation.IdPersonaNavigation.GetNombreApellido()
            }).ToList();
        }

        public List<ComunicadosDocenteDto> GetAll(int id)
        {
            var comunicados = _context.Comunicados.Include(c => c.IdUsuarioNavigation)
                .ThenInclude(u => u.IdPersonaNavigation).OrderByDescending(c => c.IdComunicado).Where(i=>i.IdDocente==id).Select(c=>new ComunicadosDocenteDto
                {
                    IdComunicado = c.IdComunicado,
                    Descripcion = c.Descripcion,
                    Fecha = c.Fecha.ToString("g"),
                    NombreApellidoEstudiante = c.IdUsuarioNavigation.IdPersonaNavigation.GetNombreApellido()
                });

            return comunicados.ToList();
        }

        public List<ComunicadoDto> GetAllByEstudiante(int id)
        {
            var comunicados = _context.Comunicados.OrderByDescending(c=>c.IdComunicado).Where(c => c.IdUsuario == id).Select(c => new ComunicadoDto
            {
                IdUsuario = c.IdUsuario, Descripcion = c.Descripcion, IdDocente = c.IdDocente,
                Docente = c.IdDocenteNavigation.IdPersonaNavigation.GetNombreApellido(),
                Fecha = c.Fecha.ToString("g"),
                IdComunicado = c.IdComunicado
            });

            return comunicados.ToList();
        }

        public List<ComunicadoDto> GetAllComunicadosDeTutor(int idTutor)
        {
            var idEstudiantes = _context.TutorEstudiante.Where(e => e.IdUsuarioTutor == idTutor)
                .Select(e => e.IdUsuarioEstudiante).ToList();

            var comunicados = _context.Comunicados.OrderByDescending(c => c.IdComunicado)
                .Where(c => idEstudiantes.Any(e => e == c.IdUsuario)).Select(c => new ComunicadoDto
            {
                IdUsuario = c.IdUsuario,
                Descripcion = c.Descripcion,
                IdDocente = c.IdDocente,
                Docente = c.IdDocenteNavigation.IdPersonaNavigation.GetNombreApellido(),
                Fecha = c.Fecha.ToString("g"),
                IdComunicado = c.IdComunicado
            });
            return comunicados.ToList();
        }
    }
}