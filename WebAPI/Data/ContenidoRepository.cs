using System;
using System.Linq;
using WebAPI.Dto;
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
        public Contenidos Crear(ContenidoDto contenido)
        {
           var contenidos= new Contenidos
            {
                Descripcion = contenido.Descripcion, Titulo = contenido.Descripcion, Unidad = contenido.Unidad,
                Video = contenido.Video
            };
           _context.Contenidos.Add(contenidos);
           _context.SaveChanges();
           return contenidos;
        }
    }
}
