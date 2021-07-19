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
                .Include(e=>e.ContenidoMateriaCurso).ThenInclude(e=>e.IdMateriaCursoNavigation)
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
    }
}
