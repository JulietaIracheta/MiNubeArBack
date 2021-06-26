using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public Usuarios GetById(int id)
        {
            return _context.Usuarios.Include(u=>u.IdPersonaNavigation).First(u => u.IdUsuario == id);
        }
        public List<EstudianteMateriasDto> GetMaterias(string email)
        {

            IQueryable<EstudianteMateriasDto> materias = from u in _context.Usuarios
                                    join me in _context.MateriaEstudiante on u.IdUsuario equals me.IdUsuario
                                    join m in _context.Materias on me.IdMateria equals m.IdMateria
                                    where u.UsuarioNombre == email
                                    select new EstudianteMateriasDto 
                                    { 
                                        IdMateria = m.IdMateria,
                                        Nombre = m.Nombre,
                                        Icon = m.Icon
                                    };

            return materias.ToList();
        }
    }
}
