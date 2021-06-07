using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;
using WebAPI.Dto;

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
            return _context.Usuarios.FirstOrDefault(x => x.UsuarioNombre == email);
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
