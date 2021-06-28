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

        public string ObtenerUsuarioChat(int userId)
        {
            if (!_context.EstudianteCurso.Any(e => e.IdUsuario == userId))
                return string.Empty;
            var curso = _context.EstudianteCurso.Include(e => e.IdCursoNavigation).First(e => e.IdUsuario == userId);
            var nombreSala = curso.IdCursoNavigation.Nombre + curso.IdCurso;
            var sala = nombreSala.Replace(" ", "");
            return sala;
        }

        public List<string> ObtenerChatsDocente(int userId)
        {
            var curso = _context.CursoDocente.Include(e => e.IdCursoNavigation).Where(e => e.IdDocente == userId);
            var listaCursos = new List<string>();

            foreach (var c in curso)
            {
                var sala = c.IdCursoNavigation.Nombre + c.IdCurso;
                sala = sala.Replace(" ", "");
                listaCursos.Add(sala);
            }

            return listaCursos;
        }
    }
}
