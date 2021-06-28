using System.Collections.Generic;
using System.Linq;
using WebAPI.Dto;
using WebAPI.Models;

namespace WebAPI.Data

{
    public interface IUsuarioRepository
    {
        Usuarios GetByEmail(string email);
        List<PersonaDto> GetEstudiantes();
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
    
    public List<PersonaDto> GetEstudiantes()
    {

        IQueryable<PersonaDto> usuarios = from u in _context.Usuarios
                                                     join ur in _context.UsuarioRol on u.IdUsuario equals ur.IdUsuario
                                                     where ur.IdRol == 1
                                                     select  new PersonaDto
                                                     {
                                                         IdUsuario = u.IdUsuario,
                                                         Nombre = u.IdPersonaNavigation.Nombre,
                                                         Apellido = u.IdPersonaNavigation.Apellido
                                                     } 
                                                     ;

        return usuarios.ToList();
    }
    
    }

}
