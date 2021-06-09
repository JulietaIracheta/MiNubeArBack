using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dto;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class EstudianteRepository
    {
        private readonly minubeDBContext _context;

        public EstudianteRepository(minubeDBContext context)
        {
            _context = context;
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
