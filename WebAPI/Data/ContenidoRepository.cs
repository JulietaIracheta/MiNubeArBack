using System;
using System.Collections.Generic;
using System.Linq;
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
            return _context.Contenidos.FirstOrDefault(x => x.IdContenido == id);
        }
        public List<Contenidos> GetByMateriaId(int cursoId)
        {
            return _context.Contenidos
                .Where(c => c.ContenidoMateriaCurso.Any(cmc => cmc.IdMateriaCursoNavigation.IdMateria == cursoId))
                .ToList();
        }
        public Contenidos Crear(ContenidoDto contenido, string contentRootPath)
        {
            var nombreVideo=FileHelper.GuardarVideo(contentRootPath, contenido.file);
            
            var contenidos= new Contenidos
            {
                Descripcion = contenido.Descripcion, Titulo = contenido.Titulo, Unidad = contenido.Unidad,
                Video = nombreVideo
            };
            var contenidoMateria = new ContenidoMateriaCurso
            {
                IdContenidoNavigation = contenidos,
                IdMateriaCurso = 1
            };
           _context.Contenidos.Add(contenidos);
           _context.ContenidoMateriaCurso.Add(contenidoMateria);
           _context.SaveChanges();
           return contenidos;
        }
    }
}
