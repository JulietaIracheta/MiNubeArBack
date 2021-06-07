using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using WebAPI.Dto;
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

        public ComunicadoRepository(minubeDBContext context)
        {
            _context = context;
        }
        public Comunicados GetById(int id)
        {
            return _context.Comunicados.FirstOrDefault(x => x.IdComunicado == id);
        }
        public List<Comunicados> Crear(ComunicadoDto comunicado)
        {
            if (string.IsNullOrEmpty(comunicado.Descripcion)) return null;

            var comunicados = new List<Comunicados>();
            
            
            if (!comunicado.IdUsuario.Any())
                comunicado.IdUsuario = _context.EstudianteCurso.Where(x => x.IdCurso == comunicado.IdCurso)
                    .Select(u => u.IdUsuario).ToList();

            foreach (var idUsuarios in comunicado.IdUsuario)
            {
                var comunicadoBase = new Comunicados {Descripcion = comunicado.Descripcion};
                comunicadoBase.IdUsuario = idUsuarios;
                comunicados.Add(comunicadoBase);
            }

            _context.Comunicados.AddRange(comunicados);
            _context.SaveChanges();
            return comunicados;
        }
        public List<Comunicados> GetAll()
        {
            var comunicados = _context.Comunicados.Include(c => c.IdUsuarioNavigation)
                .ThenInclude(u => u.IdPersonaNavigation);
            
            return comunicados.ToList();
        }
    }
}
