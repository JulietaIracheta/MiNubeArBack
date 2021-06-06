using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Dto;
using WebAPI.Models;

namespace WebAPI.Data

{
    public interface IUsuarioRepository
    {
        Usuarios GetByEmail(string email);
    }
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly minubeDBContext _context;

        public UsuarioRepository(minubeDBContext context)
        {
            _context = context;
        }
        
        public Usuarios GetByEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(u =>
                !u.FechaEliminacionLogico.HasValue && u.UsuarioNombre == email);
        }

        public List<UsuarioDto> GetAll()
        {
            var persona = _context.Usuarios.Where(u=>!u.FechaEliminacionLogico.HasValue).ToList();

            var list = persona.Select(p => new UsuarioDto
            {
                IdUsuario = p.IdUsuario,               
                UsuarioNombre = p.UsuarioNombre,
                });
            return list.ToList();
        }

    }
}
