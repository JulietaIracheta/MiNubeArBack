using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI.Dto;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface IContenidoRepository
    {
        Contenidos GetById(int id);
    }
    public class ContenidoRepository : IContenidoRepository
    {
        private readonly minubeDBContext _context;

        public ContenidoRepository(minubeDBContext context)
        {
            _context = context;
        }
        public Contenidos GetById(int id)
        {
            return _context.Contenidos.Include(e=>e.PuntajeContenido).FirstOrDefault(x => !x.FechaBaja.HasValue && x.IdContenido == id);
        }
        public List<Contenidos> GetByMateriaId(int materiaId, int cursoId)
        {
            var list= _context.Contenidos.Include(e => e.Actividades).ThenInclude(e => e.Questions)
                .ThenInclude(e => e.Answers)
                .Include(e=>e.ContenidoMateriaCurso).ThenInclude(e=>e.IdMateriaCursoNavigation).ThenInclude(e=>e.IdMateriaNavigation)
                .Where(c => !c.FechaBaja.HasValue && c.ContenidoMateriaCurso.Any(cmc => cmc.IdMateriaCursoNavigation.IdMateria == materiaId && cmc.IdMateriaCursoNavigation.IdCurso==cursoId))
                .OrderBy(e => e.Unidad)
                .ToList();
            return list;
        }

        public List<Contenidos> GetByEstudiante(int materiaId, int cursoId)
        {
            var list = _context.Contenidos.Include(e => e.Actividades).ThenInclude(e => e.Questions)
                .ThenInclude(e => e.Answers)
                .Where(c => !c.FechaBaja.HasValue && c.ContenidoMateriaCurso.Any(cmc =>
                    cmc.IdMateriaCursoNavigation.IdMateria == materiaId &&
                    cmc.IdMateriaCursoNavigation.IdCurso == cursoId))
                .OrderBy(e => e.Unidad)
                .ToList();
            return list;
        }
        public Contenidos Crear(ContenidoDto contenido, string contentRootPath)
        {
            var nombreVideo= contenido.file == null ? string.Empty : FileHelper.GuardarVideo(contentRootPath, contenido.file);

            var contenidos= new Contenidos
            {
                Descripcion = contenido.Descripcion, Titulo = contenido.Titulo, Unidad = contenido.Unidad,
                Video = nombreVideo,Fecha = DateTime.Now
            };
            var contenidoHistorico = new ContenidoHistorico
            {
                IdContenidoNavigation = contenidos
            };
            var materiaCurso =
                _context.MateriaCurso.FirstOrDefault(e =>
                    e.IdMateria == contenido.Materia && e.IdCurso == contenido.Curso);
            _context.Contenidos.Add(contenidos);
            _context.ContenidoHistorico.Add(contenidoHistorico);
            if (materiaCurso != null)
            {
                var contenidoMateria = new ContenidoMateriaCurso
                {
                    IdContenidoNavigation = contenidos,
                    IdMateriaCurso = materiaCurso.IdMateriaCurso
                };
                _context.ContenidoMateriaCurso.Add(contenidoMateria);
            }


            _context.SaveChanges();
            return contenidos;
        }

        public PromedioActividadContenidoDto GetPromedioActividadContenido(int idMateria, int idUsuario )
        {
            var total = _context.ContenidoMateriaCurso
              .Include(e => e.IdContenidoNavigation)
              .ThenInclude(e => e.PuntajeContenido)
              .Where(e => e.IdMateriaCursoNavigation.IdMateria == idMateria && !e.IdContenidoNavigation.FechaBaja.HasValue &&
                          !string.IsNullOrEmpty(e.IdContenidoNavigation.Video));
            var totalActividades = _context.ContenidoMateriaCurso
                .Include(e => e.IdContenidoNavigation)
                .ThenInclude(e => e.PuntajeContenido)
                .Where(e => e.IdMateriaCursoNavigation.IdMateria == idMateria && !e.IdContenidoNavigation.FechaBaja.HasValue);
            var promedioVisto = 0;

            if (total.Any())
            {
                promedioVisto = total.Count(e => e.IdContenidoNavigation.Visto) * 100 / total.Count();
            }

            var actResuelta = totalActividades
                .Where(e => e.IdContenidoNavigation.PuntajeContenido.Any(a => a.IdEstudiante == idUsuario))
                .Select(e => e.IdContenidoNavigation.PuntajeContenido);

            var totalActividadesResueltas = 0;
            var listaDePuntajes = new List<int>();

            foreach (var actividad in actResuelta)
            {
                foreach (var puntajeActividad in actividad)
                {
                    totalActividadesResueltas++;
                    listaDePuntajes.Add(puntajeActividad.Puntaje);
                }
            }

            var aciertos = listaDePuntajes.Count(puntaje => puntaje > 0);

            var promedioActividades = 0;
            if (totalActividadesResueltas != 0)
                promedioActividades = aciertos * 100 / totalActividadesResueltas;

            var textoActividad = TextoResueltoHelper.ObtenerTextoDeResultadoActividades(promedioActividades);

            var contenidoRes = TextoResueltoHelper.ObtenerTextoDeResultado(promedioVisto);

            return new PromedioActividadContenidoDto
            {
                ActividadResuelta = promedioActividades,
                ContenidoVisto = promedioVisto,
                ActividadResumen = textoActividad,
                ContenidoResumen = contenidoRes
            };
        }
    }
}
