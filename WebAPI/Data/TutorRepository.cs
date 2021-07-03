using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dto;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface ITutorRepository
    {
        List<TutorEstudianteDto> GetEstudiantesTutor(int id);
        List<EstudianteMateriasDto> GetMaterias(int id);
    }
    public class TutorRepository : ITutorRepository
    {
        private readonly minubeDBContext _context;
   

        public TutorRepository(minubeDBContext context)
        {
            _context = context;
        }

        public List<TutorEstudianteDto> GetEstudiantesTutor(int id)
        {
         IQueryable<TutorEstudianteDto> estudiantes = from p in _context.Personas
                                                      join u in _context.Usuarios on p.IdPersona equals u.IdPersona
                                                      join te in _context.TutorEstudiante on u.IdUsuario equals te.IdUsuarioEstudiante
                                                      where te.IdUsuarioTutor == id
                                                      select new TutorEstudianteDto
                                                      {
                                                            IdUsuario = p.Usuarios.First().IdUsuario,
                                                            Email = p.Email,
                                                            Nombre = p.Nombre,
                                                            Apellido = p.Apellido
                                                      };

            return estudiantes.ToList();
        }

        public List<EstudianteMateriasDto> GetMaterias(int id)
        {

            IQueryable<EstudianteMateriasDto> materias = from u in _context.Usuarios
                                                         join me in _context.MateriaEstudiante on u.IdUsuario equals me.IdUsuario
                                                         join m in _context.Materias on me.IdMateria equals m.IdMateria
                                                         where u.IdUsuario == id
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
